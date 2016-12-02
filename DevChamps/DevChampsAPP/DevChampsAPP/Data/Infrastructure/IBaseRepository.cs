using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DevChampsAPP
{
    public interface IBaseRepository<T> where T : class
    {
        void Insert(T TEntity);
        void Delete(T TEntity);
        void Update(T TEntity);

        T GetById(int id);
        T GetByFilter(Expression<Func<T, bool>> filter);

        IList<T> GetAll();
        IList<T> GetAllByFilter(Expression<Func<T, bool>> filter);
    }
}