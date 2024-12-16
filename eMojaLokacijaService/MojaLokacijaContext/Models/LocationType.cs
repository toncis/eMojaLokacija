using System;
using System.Collections.Generic;

namespace eMojaLokacijaService.MojaLokacijaContext.Models;

public partial class LocationType
{
    public int Id { get; set; }

    public bool Active { get; set; }

    public DateTime DateCreated { get; set; }

    public string Description { get; set; } = null!;

    public string Code { get; set; } = null!;

    public virtual ICollection<FunLocation> FunLocation { get; set; } = new List<FunLocation>();
}
