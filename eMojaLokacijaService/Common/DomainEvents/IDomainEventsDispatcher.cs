using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMojaLokacijaService.Common.Domain
{
	public interface IDomainEventsDispatcher
	{
		Task DispatchEventsAsync(List<IEvent> domainEvents, DispatchingContext dispatchingContext);

		Task DispatchEventAsync(IEvent domainEvent, DispatchingContext dispatchingContext);
	}
}
