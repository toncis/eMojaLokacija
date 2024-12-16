using System;
using System.Collections.Generic;

namespace eMojaLokacijaService.MojaLokacijaContext.Models;

public partial class VFunLocationGeoPoint
{
    public int CoordinateId { get; set; }

    public double? LonX { get; set; }

    public double? LatY { get; set; }
}
