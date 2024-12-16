using System;
using System.Collections.Generic;

namespace eMojaLokacijaService.MojaLokacijaContext.Models;

public partial class MyFunLocation
{
    public int Id { get; set; }

    public bool Active { get; set; }

    public DateTime DateCreated { get; set; }

    public int MyLocationId { get; set; }

    public int FunLocationId { get; set; }

    public virtual FunLocation FunLocation { get; set; } = null!;

    public virtual MyLocation MyLocation { get; set; } = null!;
}
