using System;
using System.Collections.Generic;

namespace eMojaLokacijaService.MojaLokacijaContext.Models;

public partial class User
{
    public int Id { get; set; }

    public bool Active { get; set; }

    public DateTime DateCreated { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<MyLocation> MyLocation { get; set; } = new List<MyLocation>();
}
