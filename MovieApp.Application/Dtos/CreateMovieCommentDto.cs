using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Application.Dtos
{
    public class CreateMovieCommentDto
    {
        public int MovieId { get; set; }
        public string Comment { get; set; }
        public double Rate { get; set; }
    }
}
