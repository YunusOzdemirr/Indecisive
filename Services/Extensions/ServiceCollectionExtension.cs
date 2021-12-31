using System;
using Data.Concrete.EntityFramework.Context;
using Microsoft.Extensions.DependencyInjection;
using Services.Abstract;
using Services.Concrete;

namespace Services.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection LoadMyService(this IServiceCollection services)
        {
            services.AddDbContext<IndecisiveContext>();
            services.AddScoped<ICategoryService, CategoryManager>();
            return services;
        }
    }
}

