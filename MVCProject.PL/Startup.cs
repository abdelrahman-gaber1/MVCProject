using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCProject.BLL.Interfaces;
using MVCProject.BLL.Repositories;
using MVCProject.DAL.Data;
using MVCProject.PL.Extensions;
using MVCProject.PL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.PL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            // Configuration : contain every thing in app settings
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the DI container.
        public void ConfigureServices(IServiceCollection services)
        {
            // any services work with dependency injection add in this method


            //we didn't detect the life time for this method 
            //because it's contain a lot of method each one register with it's life time
            //extension method with a lot of method inside it
            services.AddControllersWithViews();
            //to make CLR create object form appDbContext we must Register this service 
            //because this service works with dependency injection

            //because CLR create object and inject it in DepartmentRepository we must register
            //service to create object from DbContect this object have life time
            //services.AddSingleton<AppDbContext>();
            //AddSingeleton : per Application this object will still per App(memory)
            //from user open app and close it
            //some time the request didn't need to call db(Login) so we will not use it(memory headacke)
            //we will use it if i want to log exception or activity log
            //services.AddScoped<AppDbContext>(); // Best
            //add scope : per Request use the same object per request 
            // services.AddTransient<AppDbContext>();
            //AddTransient : per Operation each operation will create object

            //we didn't use addScope
            //AddDbContext :we use it because it do the same thing additional to option
            services.AddDbContext<AppDbContext>(options=>
            {
                // to read connection string from app settings

                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }
            ,ServiceLifetime.Scoped); //Default life time is Scoped 
            //AddDbContext have overload take parameter on type action (delegate)
            //when i create DbContext i send connection string to option in constructor of appDbcontext

            ApplicationServicesExtensions.AddApplicationService(services); // static method
            services.AddApplicationService(); //extension method
            //he need object to learn him how to mapping
            services.AddAutoMapper(M=>M.AddProfile(new mappingProfile()));
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //if you deploy your app in HTTPS and you receive request from HTTP 
            // this method will redirect it to HTTPS
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // take route and declare he match what route
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
