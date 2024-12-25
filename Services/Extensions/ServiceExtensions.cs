using App.Repositories;
using App.Repositories.Products;
using App.Services.Products;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Extensions
{
    //Controller'lar(API) hiçbir zaman direkt repository'lerle çalışmaz her zaman business logic'in(service) yazılı olduğu servislerle çalışırlar
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IProductService, ProductService>();
            return services;

        }
    }
}