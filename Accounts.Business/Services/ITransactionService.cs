
using Accounts.Business.Models;
using Accounts.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Accounts.Business.Services
{
    public interface ITransactionService
    {
        IEnumerable<Transaction> GetAll(TransactionRequest request);
        IEnumerable<Transaction> Get(Guid id);

    }
}
