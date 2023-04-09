using System;
using System.Collections.Generic;

namespace KhrDesktop.Models;

public partial class Visit
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public DateTime DateStart { get; set; }

    public DateTime DateEnd { get; set; }

    public DateTime? FinalDate { get; set; }

    public TimeOnly? FinalTime { get; set; }

    public int TypeId { get; set; }

    public int StatusId { get; set; }

    public string? StatusReason { get; set; }

    public int TargetId { get; set; }

    public int EmployeeId { get; set; }

    public string? GroupName { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;

    public virtual Target Target { get; set; } = null!;

    public virtual Type Type { get; set; } = null!;

    public virtual User? User { get; set; }

    public virtual ICollection<Visitor> Visitors { get; } = new List<Visitor>();
}
