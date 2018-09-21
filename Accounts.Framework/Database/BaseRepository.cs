using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Accounts.Framework.Database
{
    public class BaseRepository<T> : IRepository<T>
       where T : BaseEntity
    {
        /// <summary>
        /// Contexto para acesso aos dados
        /// </summary>
        protected BaseDbContext Context { get; }

        /// <summary>
        /// Constroi repositorio base
        /// </summary>
        public BaseRepository(BaseDbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Recupera lista de elementos
        /// </summary>
        public IList<T> Get()
        {
            return Context.Set<T>()
                          .AsNoTracking()
                          .ToList();
        }

        /// <summary>
        /// Recupera lista dado uma condicao
        /// </summary>
        public IList<T> Get(Expression<Func<T, bool>> condition)
        {
            return Context.Set<T>()
                          .AsNoTracking()
                          .Where(condition)
                          .ToList();
        }

        /// <summary>
        /// Busca item pela chave
        /// </summary>
        public T Get(params object[] key)
        {
            if (key == null || key.Length == 0)
                return null;
            return Context.Set<T>().Find(key);
        }

        /// <summary>
        /// Salva um elemento
        /// </summary>
        public T Save(T entity)
        {
            var dbEntity = Context.Set<T>().Find(entity.GetKey());
            if (dbEntity == null)
                Context.Set<T>().Add(entity);

            Context.SaveChanges();
            return entity;
        }


        public void BeginTransaction() => Context.BeginTransaction();
        public void CommitTransaction() => Context.CommitTransaction();
        public void RollbackTransaction() => Context.RollbackTransaction();
    }
}
