using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using BNTU_fond.Repository;
using BNTU_fond.Repository.Interfaces;
using BNTU_fond.Models;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace BNTU_fond
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
            services.AddDbContext<AppDbContext>(options =>
                   options.UseSqlServer(
                       Configuration["Data:BNTUfond:ConnectionString"]));
            services.AddTransient<IRepository<Building>, BuildingRepository>();
            services.AddTransient<IRepository<Floor>, FloorRepository>();
            services.AddTransient<IRepository<Auditory>, AuditoryRepository>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Building}/{action=Index}/{id?}");
            });

            app.UseDeveloperExceptionPage();
            app.UseDefaultFiles();
            // добавляем поддержку каталога node_modules
            app.UseFileServer(new FileServerOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, "node_modules")
                ),
                RequestPath = "/node_modules",
                EnableDirectoryBrowsing = false
            });
        }
    }
}
