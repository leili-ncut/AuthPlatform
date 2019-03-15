using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.AccessTokenValidation;
using Lil.AuthPlatform.AhphOcelot.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ocelot.Administration;
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
            Action<IdentityServerAuthenticationOptions> option = o =>
            {
                o.Authority = "http://localhost:6611"; //IdentityServer地址
                o.RequireHttpsMetadata = false;
                o.ApiName = "gateway_admin"; //网关管理的名称，对应的为客户端授权的scope
            };
            services.AddOcelot().AddAhphOcelot(options =>
            {
                //options.DbConnectionStrings = "Data Source=LJY-DUDU\\MSSQLSERVER01;Integrated Security=SSPI;Initial Catalog=AphpOcelot";
                options.DbConnectionStrings = "Data Source=LIL-AS-P2;Integrated Security=SSPI;Initial Catalog=AphpOcelot";
                // 
                //options.EnableTimer = true;
                //options.TimerDelay = 1000 * 10;
            })
                .AddAdministration("/CtrOcelot",option);
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
