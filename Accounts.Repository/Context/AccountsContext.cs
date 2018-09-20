using Accounts.Framework.Database;
using Accounts.Repository.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Repository.Context
{
    public class AccountsContext : BaseDbContext
    {
        public AccountsContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AccountConfiguration(modelBuilder);
            new PersonConfiguration(modelBuilder);
        }
    }
}
