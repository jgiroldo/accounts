using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounts.Business.Services;
using Accounts.Repository.Context;
using Accounts.Repository.Repositories;
using Accounts.Repository.Repositories.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;

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


            //CORS
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin();
            corsBuilder.AllowCredentials();
            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
            });

            //REPOSITORIOS
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            //SERVICOS
            services.AddScoped<IAccountService, AccountService>();
            
            services.AddLogging();
        }

        void ConfigureDatabase(IServiceProvider provider, DbContextOptionsBuilder options)
        {
            var connectionString = Environment.GetEnvironmentVariable("DEFAULT_CONNECTION");
            options.UseSqlServer(connectionString);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory factory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("SiteCorsPolicy");

            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
            factory.AddSerilog(Log.Logger);
            app.UseMvc();
        }
    }
}
