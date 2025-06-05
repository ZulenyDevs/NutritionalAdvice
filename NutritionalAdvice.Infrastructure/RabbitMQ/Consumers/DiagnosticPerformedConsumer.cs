using Joseco.Communication.External.Contracts.Services;
using MediatR;
using NutritionalAdvice.Application.MealPlans.CreateMealPlan;
using NutritionalAdvice.Integration.MealPlan;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NutritionalAdvice.Infrastructure.RabbitMQ.Consumers
{
	public class DiagnosticPerformedConsumer(IMediator mediator) : IIntegrationMessageConsumer<DiagnosticPerformed>
	{
		public async Task HandleAsync(DiagnosticPerformed message, CancellationToken cancellationToken)
		{
			CreateMealPlanCommand command = new(
				$"Plan Alimenticio - {message.PatientName}",
				"",
				"",
				0,
				0,
				0,
				0,
				Guid.NewGuid(),
				message.PatientId
			);

			await mediator.Send(command, cancellationToken);
		}
	}
}
