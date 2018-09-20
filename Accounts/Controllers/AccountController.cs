using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounts.Business.Exceptions;
using Accounts.Business.Models;
using Accounts.Business.Services;
using Accounts.Domain.Entities;
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
            catch(BusinessException ex)
            {
                return BadRequest(new { Id = Guid.NewGuid(), Message = ex.Message });
            }
            catch (Exception)
            {
                throw new Exception("Falha na Requisição");
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
    }
}
