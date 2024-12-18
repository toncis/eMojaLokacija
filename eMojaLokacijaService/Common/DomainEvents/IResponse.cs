using System;

namespace eMojaLokacijaService.Common.Domain
{
	/// <summary>
	/// Request-Response messaging pattern interface
	/// </summary>
	public interface IResponse
	{
		/// <summary>
		/// Unique identifier of the response. 
		/// </summary>
		Guid ResponseToken { get; }

		/// <summary>
		/// Response result. True if request was successful. 
		/// If False, Client should expect some exception explanation in Message property of the response.
		/// </summary>
		bool Success { get; set; }

		/// <summary>
		/// Text message used to describe exception that occurred while executing request.
		/// Property should be null if Success property is True.
		/// </summary>
		string Message { get; set; }
	}
}
