using System;

namespace eMojaLokacijaService.Common.Domain
{
	public interface IEvent
	{
		DateTime OccurredOn { get; }
		DispatchingContext DispatchingContext { get; }
	}
}
