using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using CarRentals.Application.Interfaces;
using CarRentals.Infrastructure.Persistence;
using CarRentals.Infrastructure.Services;
using CarRentals.Middleware;
using CarRentals.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarRentals
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddTransient<ICarService, CarService>();
            services.AddTransient<ILoanService, LoanService>();
            services.AddTransient<IUserService, UserService>();

            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("CarRentals"),
                 x => x.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
             ));

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Application";
                options.DefaultSignInScheme = "External";
            })
                .AddCookie("Application")
                .AddCookie("External")
                .AddGoogle(options =>
                {
                    options.ClientId = Configuration["GoogleAuth:ClientId"];
                    options.ClientSecret = Configuration["GoogleAuth:ClientSecret"];
                });

            // configure all policies
            services.AddAuthorization(options => new PolicyConfiguration(options).ConfigurePolicies());

            MappingConfiguration.ConfigureMappings(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseMiddleware<ErrorPageMiddleware>();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "admin/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "Default",
                    areaName: "Default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
