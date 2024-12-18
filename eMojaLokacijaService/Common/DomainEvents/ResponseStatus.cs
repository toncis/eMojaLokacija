using System;

namespace eMojaLokacijaService.Common.Domain
{
	[Serializable]
	public class ResponseStatus
	{
		public string Code { get; set; }
		public string Message { get; set; }
	}
}
