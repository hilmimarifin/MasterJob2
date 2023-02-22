using System;
using System.Collections.Generic;

namespace MasterJob.Models;

public partial class JobPosition
{
    public string Id { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? TitleId { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();

    public virtual JobTitle? Title { get; set; }
}
