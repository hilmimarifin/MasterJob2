using System;
using System.Collections.Generic;

namespace MasterJob.Models;

public partial class JobTitle
{
    public string Code { get; set; } = null!;

    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<JobPosition> JobPositions { get; } = new List<JobPosition>();
}
