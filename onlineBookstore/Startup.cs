using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using onlineBookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace onlineBookstore
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup (IConfiguration temp)
        {
            Configuration = temp;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // E: This line of code tells ASP.net to use the MVC setup
            services.AddControllersWithViews();

            services.AddDbContext<BookstoreContext>(options =>
           {
               options.UseSqlite(Configuration["ConnectionStrings:ReadingRainbow"]);
           });

            services.AddScoped<IOnlineBookstoreRepository, EFOnlineBookstoreRepository>();        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // E: This line of code tells ASP.net to use the files within the wwwroot folders
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // E: Replaced "hello world" endpoint with this line of code
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
