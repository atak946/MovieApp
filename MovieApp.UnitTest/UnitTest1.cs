using Microsoft.EntityFrameworkCore;
using MovieApp.Application.Abstract;
using MovieApp.Application.Dtos;
using MovieApp.Application.Services;
using MovieApp.Domain.Abstract;
using MovieApp.Infrastructure.Context;
using MovieApp.Infrastructure.Repository;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MovieApp.UnitTest
{
    public class Tests
    {
        private ApplicationDbContext _dbContext;
        private IUnitOfWork _unitOfWork;
        private IMovieService _movieService;
        private IMovieCommentService _movieCommentService;

        [SetUp]
        public void Setup()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("MovieDB");
            _dbContext = new ApplicationDbContext(builder.Options);
            _unitOfWork = new UnitOfWorkRepository(_dbContext);
            _movieService = new MovieService(_unitOfWork);
            _movieCommentService = new MovieCommentService(_unitOfWork);
        }

        [Test, Order(1)]
        public async Task MovieTest()
        {
            int count = GetMovieCount();

            Assert.AreEqual(0, count);

            // ---------------- CREATE MOVIE -------------------- //

            MovieDto newMovie = new MovieDto()
            {
                ImagePath = "Test.jpg",
                Title = "Test",
                Overview = "Test desc",
                ReleaseDate = System.DateTime.Now
            };

            newMovie = await _movieService.InsertAsync(newMovie);

            await _unitOfWork.SaveAsync();

            count = GetMovieCount();

            Assert.Greater(count, 0);

            // ----------------- FIND MOVIE BY ID ------------------- //

            var movie = await _movieService.FindByIdAsync(newMovie.Id);

            // ----------------- DELETE MOVIE ------------------- //

            _movieService.Delete(movie);

            await _unitOfWork.SaveAsync();

            count = GetMovieCount();

            Assert.AreEqual(0, count);
        }

        [Test, Order(2)]
        public async Task MovieCommentTest()
        {
            // ----------------- CREATE MOVIE ------------------- //

            MovieDto newMovie = new MovieDto()
            {
                ImagePath = "Test.jpg",
                Title = "Test",
                Overview = "Test desc",
                ReleaseDate = System.DateTime.Now
            };

            newMovie = await _movieService.InsertAsync(newMovie);

            await _unitOfWork.SaveAsync();

            int count = GetMovieCount();

            Assert.Greater(count, 0);

            // ----------------- GET MOVIE ------------------- //

            MovieDto movie = await _movieService.FindByIdAsync(newMovie.Id);

            Assert.IsNotNull(movie);

            // ----------------- CREATE COMMENT ------------------- //

            count = GetCommentCount(movie.Id);

            Assert.AreEqual(0, count);

            MovieCommentDto comment = new MovieCommentDto() {
                Comment = "Test",
                CreateDate = System.DateTime.Now,
                CreateUser = "UnitTest",
                MovieId = movie.Id,
                Rate = 9.0 
            };

            await _movieCommentService.InsertAsync(comment);

            await _unitOfWork.SaveAsync();

            count = GetCommentCount(movie.Id);

            Assert.AreNotEqual(0, count);
        }

        private int GetMovieCount()
        {
             return _movieService.Select(null).Count;
        }

        private int GetCommentCount(int movieId)
        {
            return _movieCommentService.Select(s => s.MovieId == movieId).Count;
        }
    }
}