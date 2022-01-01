using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Services;
using EmployeeManagement.Data.EF;
using EmployeeManagement.Data.Extensions;
using EmployeeManagement.Utils.Contants;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmployeeManagement.MVCSite
{
    public class Startup
    {
        private const string ERROR_PAGE = "/Employees/Error";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString(SystemConstants.DEFAULT_CONNECTION)));

            services.AddTransient<IEmployeeService, EmployeeService>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var dbcontext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbcontext.Database.Migrate();
                dbcontext.Seed();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(ERROR_PAGE);
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
                    pattern: "{controller=Employees}/{action=Index}/{id?}");
            });
        }
    }
}