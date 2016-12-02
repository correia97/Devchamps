using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevChampsAPP
{
    public class BaseApplicationService<T> : IBaseApplicationService<T> where T : class
    {
        readonly IBaseRepository<T> _repository;

        public BaseApplicationService(IBaseRepository<T> repo)
        {
            _repository = repo;
        }

        public void Delete(T TEntity)
        {
            try
            {
                _repository.Delete(TEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IList<T>> GetAll()
        {
            try
            {
                return await Task.FromResult(_repository.GetAll());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IList<T>> GetAllByFilter(Expression<Func<T, bool>> filter)
        {
            try
            {
                return await Task.FromResult(_repository.GetAllByFilter(filter));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter)
        {
            try
            {
                return await Task.FromResult(_repository.GetByFilter(filter));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> GetById(int id)
        {
            try
            {
                return await Task.FromResult(_repository.GetById(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(T TEntity)
        {
            try
            {
                _repository.Insert(TEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(T TEntity)
        {
            try
            {
                _repository.Update(TEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}