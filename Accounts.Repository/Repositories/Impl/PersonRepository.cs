using Accounts.Domain.Entities;
using Accounts.Framework.Database;
using Accounts.Repository.Context;

namespace Accounts.Repository.Repositories.Impl
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(AccountsContext context) : base(context)
        {
        }
    }
}
