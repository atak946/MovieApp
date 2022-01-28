using MovieApp.Application.Abstract;
using MovieApp.Application.Dtos;
using MovieApp.Application.Mapper;
using MovieApp.Domain.Abstract;
using MovieApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Application.Services
{
    public class MovieCommentService : CrudService<MovieCommentDto, MovieComment>, IMovieCommentService
    {
        public MovieCommentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
