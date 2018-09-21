using Accounts.Domain.Entities;
using Accounts.Framework.Database;
using Accounts.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.Repository.Repositories.Impl
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(AccountsContext context) : base(context)
        {
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            return Context.Set<Transaction>().AsNoTracking()
                .Include(e => e.SourceAccount)
                .Include(e => e.DestinyAccount)
                .ToList();
        }

        public IEnumerable<Transaction> GetTransactions(Func<Transaction, bool> condition)
        {
            return Context.Set<Transaction>()
                .AsNoTracking()
                .Where(e => condition(e))
                .Include(e => e.SourceAccount)
                .Include(e => e.DestinyAccount)
                .ToList();
        }
    }
}
