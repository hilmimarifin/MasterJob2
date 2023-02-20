using System;
using System.Collections.Generic;

namespace MasterJob.Models;

public partial class Employee
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? JobPositionId { get; set; }

    public string? JobTitleId { get; set; }

    public string? Address { get; set; }

    public string Nik { get; set; } = null!;
}
