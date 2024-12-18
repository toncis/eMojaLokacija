using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace eMojaLokacijaService.Common.Domain
{
	public class ParallelNoWaitMediator : Mediator
	{
		// src: https://github.com/jbogard/MediatR/blob/master/samples/MediatR.Examples.PublishStrategies/Publisher.cs

		private Func<IEnumerable<Func<INotification, CancellationToken, Task>>, INotification, CancellationToken, Task> _publish;

		public ParallelNoWaitMediator(IServiceProvider serviceFactory) : base(serviceFactory)
		{
			_publish = ParallelNoWait;
		}

		protected Task PublishCore(IEnumerable<Func<INotification, CancellationToken, Task>> allHandlers, INotification notification, CancellationToken cancellationToken)
		{
			return _publish(allHandlers, notification, cancellationToken);
		}

		private Task ParallelNoWait(IEnumerable<Func<INotification, CancellationToken, Task>> handlers, INotification notification, CancellationToken cancellationToken)
		{
			foreach (var handler in handlers)
			{
				Task.Run(() => handler(notification, cancellationToken));
			}

			return Task.CompletedTask;
		}
	}
}
