using System;

namespace MovieApp.Application.Dtos
{
    public class MovieCommentDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public string Comment { get; set; }
        public double Rate { get; set; }
    }
}
