using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounts.Business.Exceptions;
using Accounts.Business.Models;
using Accounts.Domain.Entities;
using Accounts.Domain.Enums;
using Accounts.Repository.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Accounts.Business.Services
{
    public class AccountService : IAccountService
    {
        IAccountRepository accountRepository;
        ITransactionRepository transactionRepository;
        ILogger<AccountService> logger;
        IHttpContextAccessor httpContext;

        public AccountService(IHttpContextAccessor httpContext, IAccountRepository accountRepository, ILogger<AccountService> logger, ITransactionRepository transactionRepository)
        {
            this.accountRepository = accountRepository;
            this.transactionRepository = transactionRepository;
            this.logger = logger;
            this.httpContext = httpContext;

        }

        public IEnumerable<Account> GetAll(AccountRequest request)
        {
            return accountRepository.GetAccounts(e => Filter(e, request));
        }

        public IEnumerable<Account> Get(int id)
        {
            return accountRepository.GetAccounts(e => e.Id == id);
        }

        public Account Create(Account account)
        {
            if (account == null)
                throw new BusinessException("Requisição inválida");

            accountRepository.Save(account);
            return account;
        }

        public Account Update(int id, Account account)
        {
            if (account == null)
                throw new BusinessException("Requisição inválida");

            var updateAccount = accountRepository.Get(id);
            if (updateAccount.Id == account.Id)
            {
                updateAccount = account;
                accountRepository.Save(updateAccount);
            }
            else
            {
                throw new BusinessException("Requisição inválida");
            }

            return account;
        }

        public bool Transfer(TransferViewModel transfer)
        {
            try
            {
                logger.LogInformation("Iniciando transferencia");
                accountRepository.BeginTransaction();
                var transaction = new Transaction();

                var origin = accountRepository.Get(new object[] { transfer.SourceId });
                var destiny = accountRepository.Get(new object[] { transfer.DestinyId });

                if (destiny == null)
                    throw new BusinessException($"Conta {transfer.DestinyId} não encontrada");

                if (origin == null && destiny.MasterAccount != null)
                {
                    throw new BusinessException($"Conta {transfer.DestinyId} não pode receber aporte!");

                }
                else if (origin == null && destiny.MasterAccount == null)
                {
                    destiny.Balance += transfer.Value;
                    transaction.DestinyAccountId = transfer.DestinyId;
                    transaction.Value = transfer.Value;
                    transaction.OperationType = (int)TransactionTypeEnum.INJECTION;
                    accountRepository.Save(destiny);
                    transactionRepository.Save(transaction);
                    accountRepository.CommitTransaction();

                    return true;

                }
                else
                {
                    if (destiny.MasterAccount == null)
                        throw new BusinessException($"Conta {transfer.DestinyId} é conta Matriz, não pode receber transferências!");

                    if (origin.Balance < transfer.Value)
                        throw new BusinessException($"Saldo insuficiente");

                    origin.Balance -= transfer.Value;
                    destiny.Balance += transfer.Value;

                    transaction.SourceAccountId = transfer.SourceId;
                    transaction.DestinyAccountId = transfer.DestinyId;
                    transaction.Value = transfer.Value;
                    transaction.OperationType = (int)TransactionTypeEnum.TRANSFER;

                    accountRepository.Save(origin);
                    accountRepository.Save(destiny);
                    transactionRepository.Save(transaction);

                    accountRepository.CommitTransaction();
                    return true;
                }
            }
            catch
            {
                accountRepository.RollbackTransaction();
                throw;
            }

        }

        public bool Chargeback(Transaction transaction)
        {
            try
            {
                logger.LogInformation("Iniciando Estorno");
                accountRepository.BeginTransaction();
                var newTransaction = new Transaction();

                var transactionToChargeback = transactionRepository.Get(new object[] { transaction.Id });
                var newDestiny = accountRepository.Get(new object[] { transactionToChargeback.SourceAccountId });
                var newSource = accountRepository.Get(new object[] { transactionToChargeback.DestinyAccountId });

                if (transactionToChargeback == null)
                    throw new BusinessException($"Transação {transactionToChargeback.Id} não encontrada");

                if (newSource.Balance < transactionToChargeback.Value)
                    throw new BusinessException($"Transação {transactionToChargeback.Id} não pode ser efetuada, saldo para estorno insuficiente");

                if (transactionToChargeback.IsReversed)
                    throw new BusinessException($"Transação {transactionToChargeback.Id} já realizada anteriormente");

                newDestiny.Balance += transactionToChargeback.Value;
                newSource.Balance -= transactionToChargeback.Value;

                newTransaction.SourceAccountId = transactionToChargeback.DestinyAccountId;
                newTransaction.DestinyAccountId = (int)transactionToChargeback.SourceAccountId;
                newTransaction.Value = transactionToChargeback.Value;
                newTransaction.OperationType = (int)TransactionTypeEnum.CHARGEBACK;
                transactionToChargeback.IsReversed = true;

                accountRepository.Save(newDestiny);
                accountRepository.Save(newSource);
                transactionRepository.Save(newTransaction);
                transactionRepository.Save(transactionToChargeback);

                accountRepository.CommitTransaction();
                return true;
            }
            catch
            {
                accountRepository.RollbackTransaction();
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

        public IEnumerable<AccountStatus> GetAccountStatus()
        {
            try
            {
                return ((AccountStatusEnum[])System.Enum.GetValues(typeof(AccountStatusEnum))).Select(c => new AccountStatus() { Id = (int)c, Description = c.ToString() }).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IEnumerable<TransactionType> GetTransactionTypes()
        {
            try
            {
                return ((TransactionTypeEnum[])System.Enum.GetValues(typeof(TransactionTypeEnum))).Select(c => new TransactionType() { Id = (int)c, Description = c.ToString() }).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }



    }
}
