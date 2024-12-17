using eMojaLokacijaService.MojaLokacijaService.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMojaLokacijaService.MojaLokacijaService
{
	public class MojaLokacijaService : IMojaLokacijaService
	{
		private readonly MojaLokacijaContext.MojaLokacijaContext _locationContext;
		private readonly ILogger<MojaLokacijaService> _logger;

		public MojaLokacijaService(
			MojaLokacijaContext.MojaLokacijaContext locationContext,
			ILogger<MojaLokacijaService> logger)
		{
			_locationContext = locationContext ?? throw new ArgumentException(nameof(locationContext));
			_logger = logger ?? throw new ArgumentException(nameof(logger));
		}

		public async Task<FunLocationsResponse> GetFunLocations(FunLocationsRequest request)
		{
			FunLocationsResponse retValue = new FunLocationsResponse();





			return retValue;
		}

	}
}
