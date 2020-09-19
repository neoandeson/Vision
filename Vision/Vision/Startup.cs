using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.Models;
using DataService.Services;
using DataService.Services.LogicServices;
using DataService.Services.ModelServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Hangfire;
using Hangfire.SqlServer;

namespace Vision
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

            services.AddDbContext<VisionContext>(
                option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddHangfire(x => x.UseSqlServerStorage(
                Configuration.GetConnectionString("HangfireConnection"), 
                new SqlServerStorageOptions
                {
                    PrepareSchemaIfNecessary = true
                }));

            //Add model services
            services.AddTransient<IAccountStateService, AccountStateService>();
            services.AddTransient<IPriceSectionService, PriceSectionService>();
            services.AddTransient<IBuyOrderService, BuyOrderService>();
            services.AddTransient<ISellOrderService, SellOrderService>();
            services.AddTransient<IOrderHistoryService, OrderHistoryService>();
            services.AddTransient<ISystemConfigService, SystemConfigService>();
            services.AddTransient<IHolidayService, HolidayService>();

            //Add logic services
            services.AddTransient<IBuyInService, BuyInService>();
            services.AddTransient<ISellOutService, SellOutService>();
            services.AddTransient<IUpdateTDaysService, UpdateTDaysService>();
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

            //Add Hangfire
            app.UseHangfireDashboard();
            app.UseHangfireServer();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
