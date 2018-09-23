using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounts.Business.Exceptions;
using Accounts.Business.Models;
using Accounts.Business.Services;
using Accounts.Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.Controllers
{
    [Produces("application/json")]
    [Route("api/accounts")]
    public class AccountController : Controller
    {
        IAccountService service;
        public AccountController(IAccountService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("")]
        [Produces(typeof(IEnumerable<Account>))]
        public IActionResult GetAll([FromQuery] AccountRequest request)
        {
            try
            {
                var result = service.GetAll(request);
                return Ok(result);
            }
            catch (Exception)
            {
                throw new Exception("Falha na Requisição");
            }

        }

        [HttpGet]
        [Route("{id:int}")]
        [Produces(typeof(IEnumerable<Account>))]
        public IActionResult GetAll([FromRoute(Name = "id")] int id)
        {
            try
            {
                var result = service.Get(id);
                return Ok(result);
            }
            catch (Exception)
            {
                throw new Exception("Falha na Requisição");
            }

        }

        [HttpPost]
        [Route("")]
        [Produces(typeof(Account))]
        public IActionResult Post([FromBody] Account account)
        {
            try
            {
                var result = service.Create(account);
                return Ok(result);
            }
            catch (BusinessException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception)
            {
                throw new Exception("Falha na Requisição");
            }
        }

        [HttpPut("{id}")]
        [Route("")]
        [Produces(typeof(Account))]
        public IActionResult Put(int id, [FromBody] Account account)
        {
            try
            {
                var result = service.Update(id, account);
                return Ok(result);
            }
            catch (BusinessException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception)
            {
                throw new Exception("Falha na Requisição");
            }
        }

        [HttpPost]
        [Route("transfer")]
        [Produces(typeof(bool))]
        public IActionResult Post([FromBody] TransferViewModel transfer)
        {
            try
            {
                var result = service.Transfer(transfer);
                return Ok(result);
            }
            catch (BusinessException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception)
            {
                throw new Exception("Falha na Requisição");
            }
        }

        [HttpPost]
        [Route("transfer/chargeback")]
        [Produces(typeof(bool))]
        public IActionResult Post([FromBody] Transaction transaction)
        {
            try
            {
                var result = service.Chargeback(transaction);
                return Ok(result);
            }
            catch (BusinessException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception)
            {
                throw new Exception("Falha na Requisição");
            }
        }


        [HttpGet]
        [Route("account-status")]
        public IEnumerable<AccountStatus> GetAccountStatus()
        {
            try
            {
                return service.GetAccountStatus();
            }
            catch (Exception)
            {
                throw new Exception("Falha na Requisição");
            }
        }

        [HttpGet]
        [Route("transaction-types")]
        public IEnumerable<TransactionType> GetTransactionTypes()
        {
            try
            {
                return service.GetTransactionTypes();
            }
            catch (Exception)
            {
                throw new Exception("Falha na Requisição");
            }
        }
    }
}
