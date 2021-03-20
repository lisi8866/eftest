﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MyNoteItem.Models;
using MyNoteItem.Repository;

namespace MyNoteItem
{
    public class Startup
    {
      
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            var connection = @"Server=127.0.0.1;DataBase=Note;UID=9zhou;PWD=123@123;";
            services.AddDbContext<NoteContext>(options=>options.UseSqlServer(connection));
            services.AddScoped<INoteRepository, NoteRepository>();

        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
          

            app.UseStaticFiles();

            app.UseMvc(routes =>   //为程序注册路由，默认打开的页面
        {
            routes.MapRoute(
                     name: "default",
                     template: "{controller=Note}/{action=Index}/{id?}");
        });
        }


    }
}
