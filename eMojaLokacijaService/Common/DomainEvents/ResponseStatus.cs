using System;

namespace eMojaLokacijaService.Common.Domain
{
	[Serializable]
	public class ResponseStatus
	{
		public string Code { get; set; } = String.Empty;
		public string Message { get; set; } = String.Empty;
	}
}
