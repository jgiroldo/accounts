using Accounts.Domain.Entities;
using Accounts.Framework.Database;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Accounts.Repository.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        IEnumerable<Account> GetAccounts();
        IEnumerable<Account> GetAccounts(Func<Account, bool> condition);
    }
}


