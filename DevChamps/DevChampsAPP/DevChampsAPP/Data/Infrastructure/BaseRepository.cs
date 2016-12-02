using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SQLiteNetExtensions.Extensions;

namespace DevChampsAPP
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        readonly object _lock = new object();

        public BaseRepository()
        {
            if (App.dbConn == null)
                App.dbConn = DataConfiguration.GetDatabaseConnection;

            CreateDatabase();
        }

        void CreateDatabase()
        {
            lock (_lock)
            {
                try
                {
                    App.dbConn.CreateTable<Despesa>(SQLite.CreateFlags.None);
                    App.dbConn.CreateTable<Investimento>(SQLite.CreateFlags.None);
                    App.dbConn.CreateTable<Pessoa>(SQLite.CreateFlags.None);
                    App.dbConn.CreateTable<Resultado>(SQLite.CreateFlags.None);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Delete(T TEntity)
        {
            lock (_lock)
            {
                if (TEntity == null)
                    return;

                App.dbConn.Delete<T>(TEntity);
            }
        }

        public IList<T> GetAll()
        {
            lock (_lock)
            {
                if (App.dbConn.Table<T>().Count() <= 0)
                    throw new ArgumentNullException();

                return App.dbConn.GetAllWithChildren<T>();
            }
        }

        public IList<T> GetAllByFilter(Expression<Func<T, bool>> filter)
        {
            lock (_lock)
            {
                if (filter == null)
                    throw new ArgumentNullException(nameof(filter), "Nenhum filtro foi configurado");

                var result = App.dbConn.GetAllWithChildren<T>(filter, recursive: true);
                if (result == null)
                    throw new ArgumentNullException(nameof(result), "Nenhum registro encontrado");

                return result;
            }
        }

        public T GetByFilter(Expression<Func<T, bool>> filter)
        {
            lock (_lock)
            {
                if (filter == null)
                    throw new ArgumentNullException(nameof(filter), "Nenhum filtro foi configurado");

                var result = App.dbConn.GetWithChildren<T>(filter, recursive: true);
                if (result == null)
                    throw new ArgumentNullException(nameof(result), "Nenhum registro encontrado");

                return result;
            }
        }

        public T GetById(int id)
        {
            lock (_lock)
            {
                if (id <= 0)
                    throw new ArgumentOutOfRangeException(nameof(id), "É necessário informar um ID válido");

                var result = App.dbConn.GetWithChildren<T>(id.ToString(), recursive: true);
                if (result == null)
                    throw new ArgumentNullException(nameof(result), "Nenhum registro encontrado");

                return result;
            }
        }

        public void Insert(T TEntity)
        {
            lock (_lock)
            {
                if (TEntity == null)
                    throw new ArgumentNullException(nameof(TEntity), "É preciso informar uma Entidade válida");

                if (typeof(T) != TEntity.GetType())
                    throw new ArgumentException("Foi informado uma entidade diferente do tipo instanciado do repositório", nameof(TEntity));

                App.dbConn.InsertOrReplaceWithChildren(TEntity, recursive: true);
            }
        }

        public void Update(T TEntity)
        {
            lock (_lock)
            {
                if (TEntity == null)
                    throw new ArgumentNullException(nameof(TEntity), "É preciso informar uma Entidade válida");

                if (typeof(T) != TEntity.GetType())
                    throw new ArgumentException("Foi informado uma entidade diferente do tipo instanciado do repositório", nameof(TEntity));

                App.dbConn.UpdateWithChildren(TEntity);
            }
        }
    }
}