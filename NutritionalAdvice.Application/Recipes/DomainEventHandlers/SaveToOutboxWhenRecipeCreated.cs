using Joseco.Outbox.Contracts.Model;
using Joseco.Outbox.Contracts.Service;
using MediatR;
using NutritionalAdvice.Domain.Abstractions;
using NutritionalAdvice.Domain.Recipes.Events;
using System.Threading;
using System.Threading.Tasks;

namespace NutritionalAdvice.Application.Recipes.DomainEventHandlers
{
	internal class SaveToOutboxWhenRecipeCreated(IOutboxService<DomainEvent> outboxService,
	IUnitOfWork unitOfWork) : INotificationHandler<RecipeCreated>
	{
		public async Task Handle(RecipeCreated domainEvent, CancellationToken cancellationToken)
		{

			OutboxMessage<DomainEvent> outboxMessage = new(domainEvent);

			await outboxService.AddAsync(outboxMessage);
			await unitOfWork.CommitAsync(cancellationToken);

		}
	}
}
