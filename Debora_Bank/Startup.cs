using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Debora_Bank.Context;
using Debora_Bank.Repository;
using Debora_Bank.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Debora_Bank
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc();

            services.AddDbContext<DeboraBankDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Debora_Bank"));
            });

            services.AddTransient<IDataService, DataService>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
               app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHttpsRedirection();
            serviceProvider.GetService<IDataService>().InitializeDB();
        }
    }
}
