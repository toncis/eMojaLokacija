using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMojaLokacijaService.MojaLokacijaService.Model
{
	public class FunLocationsRequest
	{
		int UserId { get; set; }

	}

	public class FunLocationsResponse
	{
		IEnumerable<FunLocationDto> funLocationDtos { get; set; } = new List<FunLocationDto>();


	}
}
