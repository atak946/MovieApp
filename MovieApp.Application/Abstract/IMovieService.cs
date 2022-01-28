using MovieApp.Application.Dtos;
using MovieApp.Domain.Abstract;
using MovieApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovieApp.Application.Abstract
{
    public interface IMovieService : ICrudService<MovieDto, Movie>
    {
    }
}
