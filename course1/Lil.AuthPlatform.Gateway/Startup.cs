using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lil.AuthPlatform.AhphOcelot.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ocelot.DependencyInjection;

namespace Lil.AuthPlatform.Gateway
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddOcelot().AddAhphOcelot(options =>
            {
                //Data Source=ServerName;Integrated Security=SSPI;Initial Catalog=Northwind
                //Data Source=LJY-DUDU\\MSSQLSERVER01\\AphpOcelot;Integrated Security=True;
                options.DbConnectionStrings = "Data Source=LJY-DUDU\\MSSQLSERVER01;Integrated Security=SSPI;Initial Catalog=AphpOcelot";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAhphOcelot().Wait();
            app.UseMvc();
        }
    }
}
