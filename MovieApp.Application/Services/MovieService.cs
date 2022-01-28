using MovieApp.Application.Abstract;
using MovieApp.Application.Dtos;
using MovieApp.Application.Mapper;
using MovieApp.Domain.Abstract;
using MovieApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovieApp.Application.Services
{
    public class MovieService : CrudService<MovieDto, Movie>, IMovieService
    {
        public MovieService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        
    }
}
