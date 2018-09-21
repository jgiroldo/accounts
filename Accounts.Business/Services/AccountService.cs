using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Accounts.Business.Exceptions;
using Accounts.Business.Models;
using Accounts.Domain.Entities;
using Accounts.Repository.Repositories;
using Microsoft.Extensions.Logging;

namespace Accounts.Business.Services
{
    public class AccountService : IAccountService
    {
        IAccountRepository repository;
        ILogger<AccountService> logger;

        public AccountService(IAccountRepository repository, ILogger<AccountService> logger)
        {
            this.repository = repository;
            this.logger = logger;
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

        public bool Transfer(TransferViewModel transfer)
        {
            try
            {
                logger.LogInformation("Iniciando transferencia");
                repository.BeginTransaction();

                var origin = repository.Get(new object[] { transfer.SourceId });
                if (origin == null)
                    throw new BusinessException($"Conta {transfer.SourceId} não encontrada");


                var destiny = repository.Get(new object[] { transfer.DestinyId });
                if (destiny == null)
                    throw new BusinessException($"Conta {transfer.DestinyId} não encontrada");

                if (destiny.MasterAccount == null)
                    throw new BusinessException($"Conta {transfer.DestinyId} é conta Matriz, não pode receber transferências!");


                if (origin.Balance <= transfer.Value)
                    throw new BusinessException($"Saldo insuficiente");


                origin.Balance -= transfer.Value;
                destiny.Balance += transfer.Value;


                repository.Save(origin);
                repository.Save(destiny);

                repository.CommitTransaction();
                return true;
            }
            catch
            {
                repository.RollbackTransaction();
                throw;
            }

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
