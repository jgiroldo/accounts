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
    public class TransactionService : ITransactionService
    {
        ITransactionRepository transactionRepository;
        ILogger<TransactionService> logger;
        IHttpContextAccessor httpContext;

        public TransactionService(IHttpContextAccessor httpContext, ILogger<TransactionService> logger, ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
            this.logger = logger;
            this.httpContext = httpContext;

        }

        public IEnumerable<Transaction> GetAll(TransactionRequest request)
        {
            return transactionRepository.GetTransactions(e => Filter(e, request));
        }

        public IEnumerable<Transaction> Get(Guid id)
        {
            return transactionRepository.GetTransactions(e => e.Id == id);
        }

        
        bool Filter(Transaction e, TransactionRequest request)
        {
            if (request == null)
                return true;

            if (!string.IsNullOrWhiteSpace(request.OperationType.ToString()) && e.OperationType == request.OperationType != true)
                return false;

            return true;
        }
        
    }
}
