using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OutLierBookStore.Context;
using OutLierBookStore.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace OutLierBookStore
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        //too add all the dependencies that we use in our application we use this method
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<BookStoreContext>(options => options.UseSqlServer("Data Source=(local);Initial Catalog=OutlierBookStore;User ID=sa;Password=Database@3142;"));

            services.AddScoped<BookRepository, BookRepository>();

            services.AddScoped<LanguageRepository, LanguageRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           app.UseRouting();

            app.UseStaticFiles();
        
           app.UseEndpoints(endpoints =>
          {
              endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
