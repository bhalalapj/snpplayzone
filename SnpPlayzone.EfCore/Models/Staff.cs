using System;
using System.Collections.Generic;

namespace SnpPlayzone.EfCore.Models;

public partial class Staff
{
    public Guid StaffId { get; set; }

    public string Name { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string? ShiftSchedule { get; set; }

    public string? PerformanceReview { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<SafetyMonitoring> SafetyMonitorings { get; set; } = new List<SafetyMonitoring>();
}
