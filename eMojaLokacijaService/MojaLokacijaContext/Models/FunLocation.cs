using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace eMojaLokacijaService.MojaLokacijaContext.Models;

public partial class FunLocation
{
    public int Id { get; set; }

    public bool Active { get; set; }

    public DateTime DateCreated { get; set; }

    public string Description { get; set; } = null!;

    public Geometry GeoPoint { get; set; } = null!;

    public int TypeId { get; set; }

    public virtual ICollection<MyFunLocation> MyFunLocation { get; set; } = new List<MyFunLocation>();

    public virtual LocationType Type { get; set; } = null!;
}
