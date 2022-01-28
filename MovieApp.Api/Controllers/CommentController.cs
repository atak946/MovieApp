using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Application.Abstract;
using MovieApp.Application.Dtos;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMovieCommentService _commentService;

        public CommentController(IMovieCommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<MovieCommentDto> Post([FromBody] CreateMovieCommentDto movieComment)
        {
            MovieCommentDto comment = await _commentService.InsertAsync(new MovieCommentDto()
            {
                Comment = movieComment.Comment,
                MovieId = movieComment.MovieId,
                Rate = movieComment.Rate,
                CreateUser = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                CreateDate = System.DateTime.Now
            });

            return comment;
        }

        [HttpGet]
        public async Task<MovieCommentDto> Get(int id)
        {
            return await _commentService.FindByIdAsync(id);
        }

        [HttpGet("GetAll")]
        public ResponseData<List<MovieCommentDto>> GetList([FromQuery]int movieId, [FromQuery] int page, [FromQuery]int limit)
        {
            var commentData = _commentService.Select(page, limit, p => p.MovieId == movieId);
            int commentCount = _commentService.Select(p => p.MovieId == movieId).Count;

            var response = new ResponseData<List<MovieCommentDto>>()
            {
                Count = commentData.Count,
                Page = page,
                PageSize = commentCount > 0 ? commentCount / limit : 1,
                Data = commentData
            };

            return response;
        }
    }
}
