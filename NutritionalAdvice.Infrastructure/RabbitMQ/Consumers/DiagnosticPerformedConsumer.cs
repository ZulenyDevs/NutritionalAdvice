using Joseco.Communication.External.Contracts.Services;
using MediatR;
using NutritionalAdvice.Application.MealPlans.CreateMealPlan;
using NutritionalAdvice.Integration.MealPlan;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NutritionalAdvice.Infrastructure.RabbitMQ.Consumers
{
	public class DiagnosticPerformedConsumer(IMediator mediator) : IIntegrationMessageConsumer<DiagnosticPerformed>
	{
		public async Task HandleAsync(DiagnosticPerformed message, CancellationToken cancellationToken)
		{
			ICollection<CreateMealTimeCommand> mealTimes = [];
			CreateMealPlanCommand command = new(
				$"Plan Alimenticio - {message.PatientId}",
				message.DiagnosticDescription,
				"",
				0,
				0,
				0,
				0,
				Guid.NewGuid(),
				message.PatientId,
				message.DiagnosticId,
				mealTimes
			);

			await mediator.Send(command, cancellationToken);
		}
	}
}
