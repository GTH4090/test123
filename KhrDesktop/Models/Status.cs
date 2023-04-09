using System;
using System.Collections.Generic;

namespace KhrDesktop.Models;

public partial class Status
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Visit> Visits { get; } = new List<Visit>();
}
