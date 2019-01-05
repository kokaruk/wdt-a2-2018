namespace WdtA2Api
{
    using System;
    using System.Data.SqlClient;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using WdtA2Api.Data;
    using WdtA2Api.Models;
    using WdtA2Api.Utils;

    public class Startup
    {
        private readonly Lazy<string> _connectionString;

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
            this._connectionString = new Lazy<string>(
                () =>
                    {
                        var secrets = this.Configuration.GetSection(nameof(DbSecrets)).Get<DbSecrets>();
                        var sqlString = new SqlConnectionStringBuilder(this.Configuration.GetConnectionString("wdtA2"))
                                            {
                                                UserID = secrets.Uid, Password = secrets.Password
                                            };
                        return sqlString.ConnectionString;
                    });
        }

        public IConfiguration Configuration { get; }

        private string ConnectionString => this._connectionString.Value;

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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<WdtA2ApiProductsContext>(options => options.UseSqlServer(this.ConnectionString));
        }
    }
}