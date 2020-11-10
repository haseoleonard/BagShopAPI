﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using BussinessLayer;
using BussinessLayer.UnitOfWork;
using DataAccessLayer;
using BussinessLayer.Repositories;
using BussinessLayer.Interfaces;
using Microsoft.AspNetCore.Hosting.Internal;

namespace BagShopAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //services.AddTransient<IHostingEnvironment>();
            services.AddTransient<LNBagShopDBEntities>();
            services.AddTransient(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));
            services.AddTransient<IProductRepository, ProductsRepository>();
            services.AddTransient<ICategoriesRepository, CategoriesRepository>();
            services.AddTransient<IOrdersRepository, OrdersRepository>();
            services.AddTransient<IOrderDetailsRepository, OrderDetailsRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", option => {
                    option.AllowAnyOrigin();
                    option.AllowAnyMethod();
                    option.AllowAnyHeader();
                    });
                //c.AddPolicy("AllowMethod", option => option.AllowAnyMethod());
                //c.AddPolicy("AllowHeader", option => option.AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseMvc();
            app.UseCors(act => {
                act.AllowAnyOrigin();
                act.AllowAnyMethod();
                act.AllowAnyHeader();
                });
        }
    }
}
