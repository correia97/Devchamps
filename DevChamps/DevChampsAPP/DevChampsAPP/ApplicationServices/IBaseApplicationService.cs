using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevChampsAPP
{
    public interface IBaseApplicationService<T> where T : class
    {
        void Insert(T TEntity);
        void Delete(T TEntity);
        void Update(T TEntity);

        Task<T> GetById(int id);
        Task<T> GetByFilter(Expression<Func<T, bool>> filter);

        Task<IList<T>> GetAll();
        Task<IList<T>> GetAllByFilter(Expression<Func<T, bool>> filter);
    }
}