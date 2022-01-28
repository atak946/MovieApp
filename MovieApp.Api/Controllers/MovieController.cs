using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Application.Abstract;
using MovieApp.Application.Dtos;
using MovieApp.Domain.Enums;

namespace MovieApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<MovieDto> Get(int id)
        {
            return await _movieService.FindByIdAsync(id);
        }

        [HttpGet("GetAll")]
        public ResponseData<List<MovieDto>> GetList([FromQuery]int page, [FromQuery]int limit, eMovieType type)
        {
            var movieData = _movieService.Select(page, limit, p => p.MovieType == type);
            int movieCount = _movieService.Select(p => p.MovieType == type).Count;

            var response = new ResponseData<List<MovieDto>>()
            {
                Count = movieData.Count,
                Page = page,
                PageSize = movieCount > 0 ? movieCount / limit : 1,
                Data = movieData
            };

            return response;
        }
    }
}