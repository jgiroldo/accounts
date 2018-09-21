using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Accounts.Framework.Database
{
    public interface IRepository<T>
    where T: BaseEntity
    {
        IList<T> Get();
        IList<T> Get(Expression<Func<T, bool>> condition);
        T Get(params object[] key);
        T Save(T entity);
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();

    }
}
