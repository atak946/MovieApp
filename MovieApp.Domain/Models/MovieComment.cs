using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Domain.Models
{
    public class MovieComment
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public string Comment { get; set; }
        public double Rate { get; set; }
    }
}
