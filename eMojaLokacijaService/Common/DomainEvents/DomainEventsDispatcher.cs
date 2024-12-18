using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMojaLokacijaService.Common.Domain
{
	public class DomainEventsDispatcher : IDomainEventsDispatcher
	{
		private readonly IMediator _mediator;

		public DomainEventsDispatcher(IMediator mediator)
		{
			_mediator = mediator;
		}

		async Task IDomainEventsDispatcher.DispatchEventsAsync(List<IEvent> domainEvents, DispatchingContext dispatchingContext)
		{
			IEnumerable<Task> tasks = domainEvents?.Select(async d =>
			{
				if (d is DomainEventBase domainEvent)
				{
					domainEvent.DispatchingContext = dispatchingContext;
					await _mediator.Publish(domainEvent);
				}
			});

			if (tasks != null)
			{
				await Task.WhenAll(tasks);
			}
		}

		async Task IDomainEventsDispatcher.DispatchEventAsync(IEvent domainEvent, DispatchingContext dispatchingContext)
		{
			if (domainEvent is DomainEventBase d)
			{
				d.DispatchingContext = dispatchingContext;
				await _mediator.Publish(d);
			}
		}
	}
}
