using MediatR;
using System;

namespace eMojaLokacijaService.Common.Domain
{
	public class DomainEventBase : IEvent, INotification
	{
		public DateTime OccurredOn { get; }

		public DispatchingContext DispatchingContext { get; set; }

		protected DomainEventBase()
		{
			OccurredOn = DateTime.Now;
		}
	}
}
