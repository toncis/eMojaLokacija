using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace eMojaLokacijaService.MojaLokacijaContext.Models;

public partial class MyLocation
{
    public int Id { get; set; }

    public bool Active { get; set; }

    public DateTime DateCreated { get; set; }

    public int UserId { get; set; }

    public Geometry GeoPoint { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<MyFunLocation> MyFunLocation { get; set; } = new List<MyFunLocation>();

    public virtual User User { get; set; } = null!;
}
