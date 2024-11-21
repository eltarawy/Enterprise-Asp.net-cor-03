using Assignment_Asp.net_cor_03.MapperProfiles;
using CompanyG02BLL.Interfaces;
using CompanyG02BLL.Repositries;
using CompanyG02DAL.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_Asp.net_cor_03
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
        {//DI=> (Scoped | Sigelton | Transiant) => lifeTime of object 
            services.AddControllersWithViews();

            services.AddDbContext<CompanyDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }/*, ServiceLifetime.Singleton*/); //one object per app
            ////services.AddTransient<IDepartmentRepository, DepartmentRepository>();//Per operation
            //services.AddScoped<IDepartmentRepository, DepartmentRepository>(); //per Request
            ////services.AddSingleton<IDepartmentRepository, DepartmentRepository>(); //Per Session  APPLication  // Caching //logger //singnarlife 

            //services.AddScoped<IEmployeerepository, EmployeeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(M => M.AddProfile(new EmployeeProfile()));
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
            app.UseHttpsRedirection();
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
