using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovieApp.Domain.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> FindByIdAsync(object EntityId);
        IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null);
        Task InsertAsync(T Entity);
        void Update(T Entity);
        Task DeleteAsync(object EntityId);
        void Delete(T Entity);
    }
}
