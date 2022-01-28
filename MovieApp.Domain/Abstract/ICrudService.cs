using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovieApp.Domain.Abstract
{
    public interface ICrudService<TDto, TEntity> where TDto : class where TEntity : class
    {       
        Task<TDto> FindByIdAsync(object id);
        List<TDto> Select(Expression<Func<TEntity, bool>> predicate = null);
        List<TDto> Select(int page = 1, int limit = 10, Expression<Func<TEntity, bool>> predicate = null);
        Task<TDto> InsertAsync(TDto dto);
        void Update(TDto dto);
        Task DeleteAsync(object id);
        void Delete(TDto dto);
    }
}
