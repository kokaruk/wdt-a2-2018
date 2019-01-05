using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WdtA2Api.Models;
using WdtA2Api.Utils;

namespace WdtA2Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _connectionString = new Lazy<string>(() =>
            {
                var secrets = Configuration.GetSection(nameof(DbSecrets)).Get<DbSecrets>();
                var sqlString = new SqlConnectionStringBuilder(Configuration.GetConnectionString("wdtA2"))
                {
                    UserID = secrets.Uid,
                    Password = secrets.Password
                };
                return sqlString.ConnectionString;
            });
        }

        public IConfiguration Configuration { get; }

        private readonly Lazy<string> _connectionString;
        private string ConnectionString => _connectionString.Value;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            Console.WriteLine(ConnectionString);
            services.AddDbContext<WdtA2ApiProductsContext>(options =>
                    options.UseSqlServer(ConnectionString));
            
        }

        // method to build connection string
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
