using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Application.Mapper
{
    public static class ObjectMapper
    {
        public static TDestination Map<TSource, TDestination>(TSource source) 
            where TDestination : class
            where TSource : class
        {
            return new AutoMapperConfiguration().Mapper.Map<TSource, TDestination>(source);
        }
    }
}
