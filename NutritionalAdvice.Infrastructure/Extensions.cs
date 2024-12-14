using NutritionalAdvice.Application;
using NutritionalAdvice.Domain.Abstractions;

using NutritionalAdvice.Infrastructure.StoredModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NutritionalAdvice.Domain.Ingredients;
using NutritionalAdvice.Infrastructure.Repositories;
using NutritionalAdvice.Infrastructure.DomainModel;

namespace NutritionalAdvice.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(config =>
                    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
                );

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<StoredDbContext>(context =>
                    context.UseMySql(connectionString,
                        ServerVersion.AutoDetect(connectionString)));
            services.AddDbContext<DomainDbContext>(context =>
                    context.UseMySql(connectionString,
                        ServerVersion.AutoDetect(connectionString)));

            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAplication();

            return services;
        }
    }
}
