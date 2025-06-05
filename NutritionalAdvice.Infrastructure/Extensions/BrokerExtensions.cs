using Joseco.Communication.External.Contracts.Services;
using Joseco.Communication.External.RabbitMQ;
using Joseco.Communication.External.RabbitMQ.Services;
//using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
using NutritionalAdvice.Infrastructure.RabbitMQ.Consumers;
using NutritionalAdvice.Integration.MealPlan;


namespace NutritionalAdvice.Infrastructure.Extensions
{
	public static class BrokerExtensions
	{
		public static IServiceCollection AddRabbitMQ(this IServiceCollection services)
		{
			using var serviceProvider = services.BuildServiceProvider();
			var rabbitMqSettings = serviceProvider.GetRequiredService<RabbitMqSettings>();

			services.AddRabbitMQ(rabbitMqSettings)
				.AddRabbitMqConsumer<DiagnosticPerformed, DiagnosticPerformedConsumer>("nutritionaladvice-diagnostic-performed");

			return services;
		}
	}
}
