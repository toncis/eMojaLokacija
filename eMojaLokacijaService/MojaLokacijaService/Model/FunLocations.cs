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
		public int UserId { get; set; }
		public Geometry MyGeoPoint { get; set; }
	}

	public class FunLocationsResponse
	{
		public IEnumerable<FunLocationDto> FunLocations { get; set; } = new List<FunLocationDto>();
	}
}
