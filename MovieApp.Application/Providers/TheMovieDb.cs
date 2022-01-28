using MovieApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Application.Providers
{
    public class TheMovieDb
    {
        private static string ApiKey = "2c28e81b0b1645f546e1c153f7e96b6d";
        private static string Host = "https://api.themoviedb.org/3/";
        private static string RequestStructure = "movie/{0}?api_key={1}&language=tr";
        private static string Popular = "popular";
        private static string TopRated = "top_rated";
        private static string Upcoming = "upcoming";

        public static string GenerateLink(eMovieType type)
        {
            return type switch
            {
                eMovieType.Top10 => Host + string.Format(RequestStructure, TopRated, ApiKey),
                eMovieType.UpComing => Host + string.Format(RequestStructure, Upcoming, ApiKey),
                eMovieType.Recommendation => Host + string.Format(RequestStructure, Popular, ApiKey),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
