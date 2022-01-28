using MovieApp.Application.Mapper;
using MovieApp.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Application.Services
{
    public class CrudService<TDto, TEntity> : ICrudService<TDto, TEntity> 
        where TEntity : class 
        where TDto : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TEntity> _repository;

        public CrudService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<TEntity>();
        }

        public void Delete(TDto dto)
        {
            _repository.Delete(ObjectMapper.Map<TDto, TEntity>(dto));
        }

        public async Task DeleteAsync(object id)
        {
            TDto movie = await FindByIdAsync(id);

            if (movie == null)
                throw new KeyNotFoundException("Film Yorumu bulunamadı");

            Delete(movie);
        }

        public async Task<TDto> FindByIdAsync(object id)
        {
            TEntity comment = await _repository.FindByIdAsync(id);

            return ObjectMapper.Map<TEntity, TDto>(comment);
        }

        public async Task<TDto> InsertAsync(TDto dto)
        {
            TEntity TEntity = ObjectMapper.Map<TDto, TEntity>(dto);

            await _repository.InsertAsync(TEntity);
            await _unitOfWork.SaveAsync();

            return ObjectMapper.Map<TEntity, TDto>(TEntity);
        }

        public List<TDto> Select(Expression<Func<TEntity, bool>> predicate = null)
        {
            var movieData = _repository.Select(predicate).ToList();

            return ObjectMapper.Map<List<TEntity>, List<TDto>>(movieData);
        }

        public List<TDto> Select(int page = 1, int limit = 10, Expression<Func<TEntity, bool>> predicate = null)
        {
            int skip = (page - 1) * limit;

            var movieData = _repository.Select(predicate).Skip(skip).Take(limit).ToList();

            return ObjectMapper.Map<List<TEntity>, List<TDto>>(movieData);
        }

        public void Update(TDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var idValue = dto.GetType().GetProperty("Id").GetValue(dto);

            Int32.TryParse(idValue.ToString(), out int id);

            if (idValue == null || id <= 0)
                throw new ArgumentException(nameof(dto), "Id için doğru bir değer girilmeli.");


            _repository.Update(ObjectMapper.Map<TDto, TEntity>(dto));
        }
    }
}
