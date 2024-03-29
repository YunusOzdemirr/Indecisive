﻿using System;
using Data.Concrete.EntityFramework.Context;
using Microsoft.Extensions.DependencyInjection;
using Services.Abstract;
using Services.Concrete;

namespace Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //Extension Method
        public static IServiceCollection LoadMyServices(this IServiceCollection services)
        {
            services.AddDbContext<IndecisiveContext>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICompanyService, CompanyManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IPremiumProductService, PremiumProductManager>();
            services.AddScoped<IRoleService, RoleManager>();
            services.AddScoped<ICategoryAndProductService, CategoryAndProductManager>();
            services.AddScoped<ISubscribeService, SubscribeManager>();
            return services;
        }
    }
}

