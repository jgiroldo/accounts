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
    [Route("api/transactions")]
    public class TransactionController : Controller
    {
        ITransactionService service;
        public TransactionController(ITransactionService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("")]
        [Produces(typeof(IEnumerable<Transaction>))]
        public IActionResult GetAll([FromQuery] TransactionRequest request)
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
        [Produces(typeof(IEnumerable<Transaction>))]
        public IActionResult GetAll([FromRoute(Name = "id")] Guid id)
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

     
    }
}
