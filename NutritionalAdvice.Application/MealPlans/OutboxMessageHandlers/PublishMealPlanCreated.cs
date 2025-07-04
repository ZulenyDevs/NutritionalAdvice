using Joseco.Communication.External.Contracts.Services;
using Joseco.Outbox.Contracts.Model;
using MediatR;
using NutritionalAdvice.Domain.MealPlans.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NutritionalAdvice.Application.MealPlans.OutboxMessageHandlers
{
	public class PublishMealPlanCreated(IExternalPublisher integrationBusService) : INotificationHandler<OutboxMessage<MealPlanCreated>>
	{
		public async Task Handle(OutboxMessage<MealPlanCreated> notification, CancellationToken cancellationToken)
		{
			var integrationMealTimes = notification.Content.MealTimes.Select(mt => new Integration.MealPlan.MealTime
			{
				Number = mt.Number,
				Type = mt.Type,
				Date = mt.Date,
				MealPlanId = mt.MealPlanId,
				RecipeId = mt.RecipeId
			}).ToList();

			Integration.MealPlan.MealPlanCreated message = new(
				notification.Content.Id,
				notification.Content.Name,
				notification.Content.Description,
				notification.Content.Goal,
				notification.Content.DailyCalories,
				notification.Content.DailyProtein,
				notification.Content.DailyCarbohydrates,
				notification.Content.DailyFats,
				notification.Content.NutritionistId,
				notification.Content.PatientId,
				notification.Content.DiagnosticId,
				integrationMealTimes,
				notification.CorrelationId,
				"nutritionaladvice"
			);

			await integrationBusService.PublishAsync(message);
		}
	}
}
