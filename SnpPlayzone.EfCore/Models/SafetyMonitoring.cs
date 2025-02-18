using System;
using System.Collections.Generic;

namespace SnpPlayzone.EfCore.Models;

public partial class SafetyMonitoring
{
    public Guid IncidentId { get; set; }

    public Guid? ChildId { get; set; }

    public Guid? StaffId { get; set; }

    public string IncidentDescription { get; set; } = null!;

    public DateTime? Timestamp { get; set; }

    public string Status { get; set; } = null!;

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Child? Child { get; set; }

    public virtual Staff? Staff { get; set; }
}
