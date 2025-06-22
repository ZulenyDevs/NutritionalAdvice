using Joseco.Communication.External.Contracts.Services;
using Joseco.Outbox.Contracts.Model;
using MediatR;
using NutritionalAdvice.Domain.Recipes.Events;
using System.Threading;
using System.Threading.Tasks;

namespace NutritionalAdvice.Application.Recipes.OutboxMessageHandlers
{
	class PublishRecipeCreated(IExternalPublisher integrationBusService) : INotificationHandler<OutboxMessage<RecipeCreated>>
	{
		public async Task Handle(OutboxMessage<RecipeCreated> notification, CancellationToken cancellationToken)
		{
			Integration.Recipe.RecipeCreated message = new(
				notification.Content.RecipeId,
				notification.Content.Name,
				notification.Content.Description,
				notification.CorrelationId,
				"nutritionaladvice"
			);

			await integrationBusService.PublishAsync(message);
		}
	}
}
