using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Accounts.Business.Exceptions;
using Accounts.Business.Models;
using Accounts.Domain.Entities;
using Accounts.Repository.Repositories;

namespace Accounts.Business.Services
{
    public class AccountService : IAccountService
    {
        IAccountRepository repository;

        public AccountService(IAccountRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Account> GetAll(AccountRequest request)
        {
            return repository.GetAccounts(e => Filter(e, request));
        }

        public IEnumerable<Account> Get(int id)
        {
            return repository.GetAccounts(e => e.Id == id);
        }

        public Account Create(Account account)
        {
            if (account == null)
                throw new BusinessException("Requisição inválida");

            repository.Save(account);
            return account;
        }

        bool Filter(Account e, AccountRequest request)
        {
            if (request == null)
                return true;

            if (!string.IsNullOrWhiteSpace(request.Name) && e.Name?.Contains(request.Name) != true)
                return false;

            return true;
        }
    }
}
