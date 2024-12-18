using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMojaLokacijaService.MojaLokacijaService.Model
{
    public class FunLocationDto
    {
        public int Id { get; set; }
        public string LocationType { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public Geometry GeoPoint { get; set; } = null!;
    }
}
