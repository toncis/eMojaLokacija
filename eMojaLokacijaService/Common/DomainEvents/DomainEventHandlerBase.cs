using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace eMojaLokacijaService.Common.Domain
{
	/// <summary>
	/// Base class for domain event handler. Implements INotificationHandler for MediatrR usage.
	/// </summary>
	/// <typeparam name="TDomainEvent"></typeparam>
	public abstract class DomainEventHandlerBase<TDomainEvent> : INotificationHandler<TDomainEvent>
		where TDomainEvent : INotification
	{
		public abstract Task Handle(TDomainEvent notification, CancellationToken cancellationToken);
	}
}
