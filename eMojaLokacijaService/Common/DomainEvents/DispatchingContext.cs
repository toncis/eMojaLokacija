using System;
using System.Collections.Generic;

namespace eMojaLokacijaService.Common.Domain
{
	public class DispatchingContext
	{
		public Guid RequestToken { get; init; }
		public Guid AuthenticatedUserId { get; init; }
		public List<string> AuthenticatedUserRoles { get; init; } = new List<string>();

		public DispatchingContext(RequestBase request)
		{
			// fix za deserialize gdje se zove konstruktor sa null
			// todo: izmijeniti kasnije da radi ispravno i bez ovoga
			if (request != null)
			{
				this.RequestToken = request.RequestToken;
				this.AuthenticatedUserId = request.AuthenticatedUserId;
				this.AuthenticatedUserRoles = request.AuthenticatedUserRoles;
			}
		}
	}
}
