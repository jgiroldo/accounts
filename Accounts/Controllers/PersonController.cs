using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounts.Business.Exceptions;
using Accounts.Business.Models;
using Accounts.Business.Services;
using Accounts.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.Controllers
{
    [Produces("application/json")]
    [Route("api/person")]
    public class PersonController : Controller
    {
        IPersonService service;
        public PersonController(IPersonService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("")]
        [Produces(typeof(IEnumerable<Person>))]
        public IActionResult GetAll([FromQuery] PersonRequest request)
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
        [Produces(typeof(IEnumerable<Person>))]
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
        [Produces(typeof(Person))]
        public IActionResult Post([FromBody] Person person)
        {
            try
            {
                var result = service.Create(person);
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
        [Produces(typeof(Person))]
        public IActionResult Put(int id, [FromBody] Person person)
        {
            try
            {
                var result = service.Update(id,person);
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

    }
}
