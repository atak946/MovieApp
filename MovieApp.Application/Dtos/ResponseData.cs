using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Application.Dtos
{
    public class ResponseData<T>
    {
        public int Page { get; set; }
        public int Count { get; set; }
        public int PageSize { get; set; }
        public T Data { get; set; }
    }
}
