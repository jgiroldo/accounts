using Accounts.Domain.Entities;
using Accounts.Framework.Database;
using Accounts.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Accounts.Repository.Repositories.Impl
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(AccountsContext context) : base(context)
        {
        }

        public IEnumerable<Person> GetPersons()
        {
            return Context.Set<Person>().AsNoTracking().ToList();
        }

        public IEnumerable<Person> GetPersons(Func<Person, bool> condition)
        {
            return Context.Set<Person>().AsNoTracking().Where(e => condition(e)).ToList();
        }
    }
}
