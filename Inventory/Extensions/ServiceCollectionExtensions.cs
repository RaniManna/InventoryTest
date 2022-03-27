using Inventory.API.Services.Products;
using Inventory.Domain.Interfaces;
using Inventory.Domain.Products;
using Inventory.Infrastructure;
using Inventory.Infrastructure.Data;
using Inventory.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddScoped<IProductRepository, ProductRepository>();
        }

        public static IServiceCollection ConfigureUnitOfWork(this IServiceCollection services)
        {
            return services
                .AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static IServiceCollection ConfigureSqlConnection(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<InventoryContext>(options =>
                     options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        }

        public static IServiceCollection ConfigureBusinessServices(this IServiceCollection services)
        {
            return services
                .AddScoped<ProductService>();
        }

        public static void ConfigureMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperInitilizer));
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            var builder = services.AddCors(r => {
                r.AddPolicy("sheetyPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
        public static void ConfigureNewtonsoftJson(this IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            }
      );
        }

    }
}
