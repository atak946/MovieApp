using MovieApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Domain.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string ImagePath { get; set; }
        public DateTime ReleaseDate { get; set; }
        public eMovieType MovieType { get; set; }
    }
}
