using Accounts.Domain.Entities;
using Accounts.Framework.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounts.Repository.Repositories
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        IEnumerable<Transaction> GetTransactions();
        IEnumerable<Transaction> GetTransactions(Func<Transaction, bool> condition);
    }
}
