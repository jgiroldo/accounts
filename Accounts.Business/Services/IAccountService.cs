
using Accounts.Business.Models;
using Accounts.Domain.Entities;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;

namespace Accounts.Business.Services
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAll(AccountRequest request);
        IEnumerable<Account> Get(int id);
        Account Create(Account request);
        Account Update(int id, Account request);
        bool Transfer(TransferViewModel transfer);
        bool Chargeback(Transaction transaction);
        IEnumerable<AccountStatus> GetAccountStatus();
        IEnumerable<TransactionType> GetTransactionTypes();

    }
}
