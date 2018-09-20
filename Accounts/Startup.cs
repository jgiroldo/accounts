using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounts.Business.Services;
using Accounts.Repository.Context;
using Accounts.Repository.Repositories;
using Accounts.Repository.Repositories.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Accounts
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<AccountsContext>(ConfigureDatabase);

            //REPOSITORIOS
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();

            //SERVICOS
            services.AddScoped<IAccountService, AccountService>();
        }

        void ConfigureDatabase(IServiceProvider provider, DbContextOptionsBuilder options)
        {
            var connectionString = Environment.GetEnvironmentVariable("DEFAULT_CONNECTION");//Configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
