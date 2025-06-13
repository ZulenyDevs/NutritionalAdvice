using Joseco.Outbox.EFCore;
using Joseco.Outbox.EFCore.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NutritionalAdvice.Application;
using NutritionalAdvice.Domain.Abstractions;
using NutritionalAdvice.Domain.Ingredients;
using NutritionalAdvice.Domain.MealPlans;
using NutritionalAdvice.Domain.Recipes;
using NutritionalAdvice.Infrastructure.DomainModel;
using NutritionalAdvice.Infrastructure.Extensions;
using NutritionalAdvice.Infrastructure.Repositories;
using NutritionalAdvice.Infrastructure.StoredModel;
using System.Reflection;

namespace NutritionalAdvice.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment, string serviceName)
		{
			services.AddMediatR(config =>
					config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
				);

			var connectionString = configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<StoredDbContext>(context =>
					context.UseNpgsql(connectionString));
			services.AddDbContext<DomainDbContext>(context =>
					context.UseNpgsql(connectionString));

			services.AddScoped<IUnitOfWork, UnitOfWork>()
					.AddScoped<IIngredientRepository, IngredientRepository>()
					.AddScoped<IRecipeRepository, RecipeRepository>()
					.AddScoped<IMealPlanRepository, MealPlanRepository>()
					.AddScoped<IOutboxDatabase<DomainEvent>, UnitOfWork>()
					.AddOutbox<DomainEvent>();

			services.AddAplication()
				.AddSecrets(configuration, environment)
				.AddRabbitMQ();

			return services;
		}
	}
}
