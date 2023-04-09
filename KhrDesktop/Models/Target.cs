using System;
using System.Collections.Generic;

namespace KhrDesktop.Models;

public partial class Target
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Visit> Visits { get; } = new List<Visit>();
}
