using Accounts.Domain.Entities;
using Accounts.Framework.Database;
using System;
using System.Collections.Generic;

namespace Accounts.Repository.Repositories
{
    public interface IPersonRepository : IRepository<Person> {
        IEnumerable<Person> GetPersons();
        IEnumerable<Person> GetPersons(Func<Person, bool> condition);
    }
}
