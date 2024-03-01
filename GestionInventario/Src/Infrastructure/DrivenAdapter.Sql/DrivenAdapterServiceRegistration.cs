using Application.Contracts.Infrastructure;
using DrivenAdapter.Sql.Persistence;
using DrivenAdapter.Sql.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DrivenAdapter.Sql
{
    public static class DrivenAdapterServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductsDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
            );

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
