using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShopAdmin.Domain.Contracts;
using OnlineShopAdmin.LoggerService;
using OnlineShopAdmin.DataAccess.Repositories;
using OnlineShopAdmin.DataAccess.DbContexts;

namespace OnlineShopAdmin
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

            services.AddControllersWithViews();
            string LDBconnectionString = Configuration.GetConnectionString("LDBconnectionString");
            //string AzureDBconnectionString = Configuration.GetConnectionString("AzureDBconnectionString");
            //services.AddDbContext<AdventureWorksLT2019Context>(x =>
            //   x.UseLazyLoadingProxies()
            //   .UseSqlServer(LDBconnectionString));
            services.AddDbContext<AdventureWorksLT2019Context>(o =>
            {
                o.UseLazyLoadingProxies()
                .UseSqlServer(Configuration.GetConnectionString("LDBconnectionString"));
            });




            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

           

            services.AddSingleton<ILoggerManager, LoggerManager>();
            

           
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
            }
            app.UseStaticFiles();

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
