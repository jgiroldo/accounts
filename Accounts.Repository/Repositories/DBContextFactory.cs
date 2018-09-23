using Accounts.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounts.Repository.Repositories
{
    public class DbContextFactory : IDesignTimeDbContextFactory<AccountsContext>
    {
        public AccountsContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<AccountsContext>()
                            .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\PROJETOS\accountsDB.mdf;Integrated Security=True;Connect Timeout=30")
                            .Options;

            return new AccountsContext(options);
        }
    }
}