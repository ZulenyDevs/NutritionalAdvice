using Joseco.Outbox.Contracts.Model;
using Joseco.Outbox.Contracts.Service;
using MediatR;
using NutritionalAdvice.Domain.Abstractions;
using NutritionalAdvice.Domain.MealPlans.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NutritionalAdvice.Application.MealPlans.DomainEventHandlers
{
	internal class SaveToOutboxWhenMealPlanCreated(IOutboxService<DomainEvent> outboxService, IUnitOfWork unitOfWork) : INotificationHandler<MealPlanCreated>
	{
		public async Task Handle(MealPlanCreated domainEvent, CancellationToken cancellationToken)
		{
			OutboxMessage<DomainEvent> outboxMessage = new(domainEvent);

			await outboxService.AddAsync(outboxMessage);
			await unitOfWork.CommitAsync(cancellationToken);
		}
	}
}
