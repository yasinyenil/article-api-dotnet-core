using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#region Global Usings
using Article.Managers.Abstracts;
using Article.Managers.Concretes;
using Article.Models.EntitiesOfProjects.DBContexts;
using Microsoft.EntityFrameworkCore;
#endregion

namespace Article.Services.WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                    .SetCompatibilityVersion(version: CompatibilityVersion.Version_2_2);

            services.AddDbContext<ArticleContext>(x => x.UseSqlServer("Server=(local); Initial Catalog=ArticleDB; Integrated Security=true;"));

            services.AddTransient<IManagerUser, ManagerUser>();
            services.AddTransient<IManagerPost, ManagerPost>();
            services.AddTransient<IManagerCategory, ManagerCategory>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
