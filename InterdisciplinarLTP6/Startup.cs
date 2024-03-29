﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterdisciplinarLTP6.Domain.Commands.Handlers;
using InterdisciplinarLTP6.Domain.Queries;
using InterdisciplinarLTP6.Domain.Repositories;
using InterdisciplinarLTP6.Infra.DataSource;
using InterdisciplinarLTP6.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace InterdisciplinarLTP6
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDB, MSSQL>();
            services.AddTransient<IRepositoryEmployee, RepositoryEmployee>();
            services.AddTransient<IRepositoryVehicle, RepositoryVehicle>();
            services.AddTransient<EmployeeCommandHandler>();
            services.AddTransient<EmployeeQuery>();
            services.AddTransient<VehicleQuery>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvc(routes => {
                routes.MapRoute("default", "{controller=Employee}/{action=Index}/{id?}");
            });
        }
    }
}
