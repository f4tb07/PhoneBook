using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using TraningPhonebook.Infrastrucher;
using TraningPhonebook.Core;
using TraningPhonebook.Contracts;
using Microsoft.Extensions.Configuration;
using TraningPhonebook.Infrastrucher.Repositories;

namespace PhoneBookUI
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(mvcopt => mvcopt.EnableEndpointRouting = false) ;
            string cnn = Configuration.GetConnectionString("PhoneBook");
            services.AddDbContext<PhoneBookRepository>(c => c.UseSqlServer(Configuration.GetConnectionString("PhoneBook")),ServiceLifetime.Scoped);
            //services.AddScoped<IBaseRpository, BaseRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IContactTypeRepository, ContactTypeRepository>();
            services.AddScoped<IContactItemRepository, ContactItemsRepository>();
            // services.AddScoped<IUserRepository, UserRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseMvc(route => {
                route.MapRoute("Default", "{controller=home}/{action=index}/{id?}");
            });
        }
    }
}
