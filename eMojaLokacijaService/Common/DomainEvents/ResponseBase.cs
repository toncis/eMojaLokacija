using System;
using System.Collections.Generic;

namespace eMojaLokacijaService.Common.Domain
{
	[Serializable]
	public abstract class ResponseBase<T> : IResponse where T : IRequest
	{
		protected ResponseBase()
		{
			Statuses = new List<ResponseStatus>();
		}

		/// <summary>
		/// Unique identifier of the response. 
		/// </summary>
		public Guid ResponseToken { get; private set; } = Guid.NewGuid();

		/// <summary>
		/// Response result. True if request was successful. 
		/// If False, Client should expect some exception explanation in Message property of the response.
		/// </summary>
		public bool Success { get; set; }

		/// <summary>
		/// Text message used to describe exception that occurred while executing request.
		/// Property should be null if Success property is True.
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// Resulting statuses code for the request.
		/// </summary>
		public List<ResponseStatus> Statuses { get; set; }

		/// <summary>
		/// Request that invoked this response.
		/// </summary>
		public T Request { get; set; }
	}
}
