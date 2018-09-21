using Accounts.Business.Models;
using Accounts.Domain.Entities;
using System.Collections.Generic;

namespace Accounts.Business.Services
{
    public interface IPersonService
    {
        IEnumerable<Person> GetAll(PersonRequest request);
        IEnumerable<Person> Get(int id);
        Person Create(Person request);
        Person Update(int id, Person request);
    }
}
