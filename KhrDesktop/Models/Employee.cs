using System;
using System.Collections.Generic;

namespace KhrDesktop.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public int? DepartmentId { get; set; }

    public int? DivisionId { get; set; }

    public string Code { get; set; } = null!;

    public virtual Department? Department { get; set; }

    public virtual Division? Division { get; set; }

    public virtual ICollection<Visit> Visits { get; } = new List<Visit>();
}
