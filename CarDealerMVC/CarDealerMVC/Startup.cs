using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CarDealerMVC.Data;
using CarDealerMVC.Entities;
using CarDealerMVC.Services;
using CarDealerMVC.Services.Contracts;

namespace CarDealerMVC
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
            services.AddDbContext<CarDealerDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<CarDealerDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<ICustomerServices, CustomerServices>();
            services.AddTransient<ICarServices, CarServices>();
            services.AddTransient<ISupplierServices, SupplierServices>();
            services.AddTransient<ISaleServices, SaleServices>();
            services.AddTransient<IPartsServices, PartsServices>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "customers",
                template: "customers/all/{sort}",
                defaults: new { controller = "Customers", action = "All" });


                routes.MapRoute(
                    name: "customerById",
                    template: "customers/{id}",
                    defaults: new { controller = "Customers", action = "CustomerById" });

                routes.MapRoute(
                    name: "cars",
                    template: "cars/{make}",
                    defaults: new { controller = "Cars", action = "CarsByMake" });

                routes.MapRoute(
                 name: "parts",
                 template: "cars/{id}/parts",
                 defaults: new { controller = "Cars", action = "CarParts" });

                routes.MapRoute(
                name: "all",
                template: "Cars/All", 
                defaults: new { controller = "Cars", action = "All" });

                routes.MapRoute(
                    name: "supplier",
                    template: "suppliers/{type}",
                    defaults: new { controller = "Suppliers", action = "Filter" });

                routes.MapRoute(name: "sales",
                    template: "Sales/{id?}",
                       defaults: new { controller = "Sales", action = "SelectSale" });

                routes.MapRoute(name: "salesDiscounts",
                     template: "Sales/discounted/{percent}",
                        defaults: new { controller = "Sales", action = "DiscountByPercentage" });

                routes.MapRoute(name: "discounts",
                    template: "Sales/discounted",
                       defaults: new { controller = "Sales", action = "SalesWithDiscount" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
