using Hangfire;
using Hangfire.Common;
using MovieApp.Application.Abstract;
using MovieApp.Application.Dtos;
using MovieApp.Application.Providers;
using MovieApp.Domain.Enums;
using MovieApp.Domain.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Infrastructure.Repository.HangFire
{
    public class MovieOperation
    {
        private readonly IRecurringJobManager _recurringJob;
        private readonly IMovieService _movieService;
        private readonly int _dataLimit;
        private int _insertedMovieCount = 0;

        public MovieOperation(IRecurringJobManager recurringJob, IMovieService movieService, int dataLimit = 100)
        {
            _recurringJob = recurringJob;
            _movieService = movieService;
            _dataLimit = dataLimit;

            // 0 */1 * * * = her saat başı çalışması için. https://crontab.guru/#0_*/1_*_*_*
            _recurringJob.AddOrUpdate("TheMovieDb", () => Start(), "* * * * *");
        }

        public async Task Start()
        {
            await FetchMovieList(eMovieType.Top10);
            await FetchMovieList(eMovieType.UpComing);
            await FetchMovieList(eMovieType.Recommendation);
        }

        private void ClearRequestConfiguration()
        {
            _insertedMovieCount = 0;
        }

        private async Task FetchMovieList(eMovieType type)
        {
            ClearRequestConfiguration();

            //"https://api.themoviedb.org/3/movie/popular?api_key=2c28e81b0b1645f546e1c153f7e96b6d&language=tr"
            var client = new RestClient(TheMovieDb.GenerateLink(type));

            bool IsCompleted = false;

            int movieCount = _movieService.Select(s => s.MovieType == type).Count();

            int currentPage = 1;

            if(movieCount > _dataLimit)
            {
                currentPage = movieCount / _dataLimit;
            }

            if (currentPage > 25) return;

            while (IsCompleted != true)
            {
                var request = new RestRequest();
                request.AddQueryParameter("page", currentPage);
                var response = await client.GetAsync<TheMovieDbResponse>(request);

                if (response == null || !response.results.Any()) IsCompleted = true;

                movieCount = _movieService.Select(s => s.MovieType == type).Count();

                if (movieCount >= response.total_results) IsCompleted = true;

                foreach (var movieDbItem in response.results)
                {
                    if (CheckMovieDublication(type, movieDbItem)) continue;

                    await CreateNewMovie(type, movieDbItem);

                    IsCompleted = _insertedMovieCount >= _dataLimit;
                }

                currentPage++;
            }
        }

        private async Task CreateNewMovie(eMovieType type, ResponseContent item)
        {
            try
            {
                MovieDto movie = new MovieDto()
                {
                    MovieId = item.id,
                    ImagePath = item.poster_path,
                    Overview = item.overview,
                    Title = item.title,
                    MovieType = type
                };

                var convertStatus = DateTime.TryParse(item.release_date, out DateTime ReleaseDate);

                if (convertStatus) movie.ReleaseDate = ReleaseDate;

                await _movieService.InsertAsync(movie);

                _insertedMovieCount++;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private bool CheckMovieDublication(eMovieType type, ResponseContent item)
        {
            return _movieService.Select(s => s.MovieType == type && s.MovieId == item.id).Any();
        }
    }
}
