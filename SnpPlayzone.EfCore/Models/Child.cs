using System;
using System.Collections.Generic;

namespace SnpPlayzone.EfCore.Models;

public partial class Child
{
    public Guid ChildId { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public string GuardianName { get; set; } = null!;

    public string EmergencyContact { get; set; } = null!;

    public string? Allergies { get; set; }

    public string? Preferences { get; set; }

    public byte[]? ProfilePicture { get; set; }

    public Guid? MembershipId { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<EventManagement> EventManagements { get; set; } = new List<EventManagement>();

    public virtual Membership? Membership { get; set; }

    public virtual ICollection<SafetyMonitoring> SafetyMonitorings { get; set; } = new List<SafetyMonitoring>();

    public virtual ICollection<VisitHistory> VisitHistories { get; set; } = new List<VisitHistory>();
}
