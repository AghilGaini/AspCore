using Database.Domain.Interfaces;
using DatabaseAccess.EFCore;
using DatabaseAccess.EFCore.Models;
using DatabaseAccess.EFCore.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPanel
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            #region Repositories

            services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();
            services.AddScoped<IVwUserRolePermisionRepository, VwUserRolePermisionRepository>();
            #endregion

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AppCoreDB")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>();

            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                options.Filters.Add(new AuthorizeFilter(policy));

                options.EnableEndpointRouting = false;
            });

            services.AddAuthorization();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Error/{0}");

                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMvc(routes =>
            {
                routes.MapRoute("Default", "{controller=Home}/{action=Index}/{Id?}");
            });

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
