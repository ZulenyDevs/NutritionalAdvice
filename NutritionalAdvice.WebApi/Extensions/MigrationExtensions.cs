using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NutritionalAdvice.Infrastructure.Repositories;

namespace NutritionalAdvice.WebApi.Extensions
{
	public static class MigrationExtensions
	{
		public static void ApplyMigrations(this IApplicationBuilder app)
		{
			using IServiceScope scope = app.ApplicationServices.CreateScope();

			using var db =
				scope.ServiceProvider.GetRequiredService<IDatabase>();

			db.Migrate();


		}
	}
}
