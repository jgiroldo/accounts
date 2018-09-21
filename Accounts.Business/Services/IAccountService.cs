
using Accounts.Business.Models;
using Accounts.Domain.Entities;
using System.Collections.Generic;

namespace Accounts.Business.Services
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAll(AccountRequest request);
        IEnumerable<Account> Get(int id);
        Account Create(Account request);
        bool Transfer(TransferViewModel transfer);
    }
}
