using Accounts.Business.Exceptions;
using Accounts.Business.Models;
using Accounts.Domain.Entities;
using Accounts.Repository.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounts.Business.Services
{
    public class PersonService : IPersonService
    {
        IPersonRepository personRepository;
        ILogger<PersonService> logger;
        IHttpContextAccessor httpContext;

        public PersonService(IHttpContextAccessor httpContext, IPersonRepository personRepository, ILogger<PersonService> logger, ITransactionRepository transactionRepository)
        {
            this.personRepository = personRepository;
            this.logger = logger;
            this.httpContext = httpContext;

        }

        public IEnumerable<Person> GetAll(PersonRequest request)
        {
            return personRepository.GetPersons(e => Filter(e, request));
        }



        public IEnumerable<Person> Get(int id)
        {
            return personRepository.GetPersons(e => e.Id == id);
        }

        public Person Create(Person person)
        {
            if (person == null)
                throw new BusinessException("Invalid request");

            personRepository.Save(person);
            return person;
        }

        public Person Update(int id, Person person)
        {
            if (person == null)
                throw new BusinessException("Invalid request");

            var updatePerson = personRepository.Get(id);
            if (updatePerson.Id == person.Id)
            {
                updatePerson = person;
                personRepository.Save(updatePerson);
            }
            else
            {
                throw new BusinessException("Invalid request");
            }

            return person;
        }

        bool Filter(Person e, PersonRequest request)
        {
            if (request == null)
                return true;

            if (!string.IsNullOrWhiteSpace(request.CpfCnpj) && e.CpfCnpj?.Contains(request.CpfCnpj) != true)
                return false;

            if (!string.IsNullOrWhiteSpace(request.SocialName) && e.SocialName?.ToLower().Contains(request.SocialName.ToLower()) != true)
                return false;

            if (!string.IsNullOrWhiteSpace(request.Name) && e.Name?.ToLower().Contains(request.Name.ToLower()) != true)
                return false;

            if (!string.IsNullOrWhiteSpace(request.ConpanyName) && e.ConpanyName?.ToLower().Contains(request.ConpanyName.ToLower()) != true)
                return false;

            return true;
        }
    }
}
