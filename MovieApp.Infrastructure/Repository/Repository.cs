using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Abstract;
using MovieApp.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Infrastructure.Repository
{
    public class Repository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task DeleteAsync(object EntityId)
        {
            T entityToDelete = await _dbSet.FindAsync(EntityId);

            Delete(entityToDelete);
        }

        public virtual void Delete(T Entity)
        {
            var contextEntry = _context.Entry(Entity);

            if (contextEntry.State != EntityState.Deleted)
            {
                _context.Entry(Entity).State = EntityState.Deleted;
                _dbSet.Attach(Entity);
            }

            _dbSet.Remove(Entity);
        }

        public virtual async Task<T> FindByIdAsync(object EntityId)
        {
            return await _dbSet.FindAsync(EntityId);
        }

        public virtual async Task InsertAsync(T Entity)
        {
            await _dbSet.AddAsync(Entity);
        }

        public virtual IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null)
        {
            if (Filter != null)
            {
                return _dbSet.Where(Filter);
            }

            return _dbSet;
        }

        public virtual void Update(T Entity)
        {
            _dbSet.Attach(Entity);
            _context.Entry(Entity).State = EntityState.Modified;
        }
    }
}
