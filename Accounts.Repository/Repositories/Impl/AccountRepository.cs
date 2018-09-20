using Accounts.Domain.Entities;
using Accounts.Framework.Database;
using Accounts.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Accounts.Repository.Repositories.Impl
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(AccountsContext context) : base(context)
        {
        }

        public IEnumerable<Account> GetAccounts()
        {
            return Context.Set<Account>().AsNoTracking().Include(e => e.Person).ToList();
        }

        public IEnumerable<Account> GetAccounts(Func<Account, bool> condition)
        {
            return Context.Set<Account>().AsNoTracking().Where(e => condition(e)).Include(e => e.Person).ToList();
        }
    }
}
