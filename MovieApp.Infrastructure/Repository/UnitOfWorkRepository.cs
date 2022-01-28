using MovieApp.Domain.Abstract;
using MovieApp.Domain.Models;
using MovieApp.Infrastructure.Context;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace MovieApp.Infrastructure.Repository
{
    public class UnitOfWorkRepository : IUnitOfWork
    {
        private bool _disposed = false;
        private readonly ApplicationDbContext _context;

        public UnitOfWorkRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_context);
        }
    }
}
