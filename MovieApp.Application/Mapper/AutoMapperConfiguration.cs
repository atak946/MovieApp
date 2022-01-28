using AutoMapper;
using MovieApp.Application.Dtos;
using MovieApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Application.Mapper
{
    public class AutoMapperConfiguration
    {
        public readonly IMapper Mapper;
        public AutoMapperConfiguration()
        {
            var config = new MapperConfiguration(cfg => Configuration(cfg));

            Mapper = config.CreateMapper();
        }

        private IMapperConfigurationExpression Configuration(IMapperConfigurationExpression mapper)
        {
            mapper.CreateMap<Movie, MovieDto>().ReverseMap();
            mapper.CreateMap<MovieComment, MovieCommentDto>().ReverseMap();

            return mapper;
        }
    }
}
