using System;
using System.Collections.Generic;

namespace SnpPlayzone.EfCore.Models;

public partial class EventManagement
{
    public Guid EventId { get; set; }

    public string EventName { get; set; } = null!;

    public Guid? GuardianId { get; set; }

    public Guid? ChildId { get; set; }

    public DateOnly EventDate { get; set; }

    public string PackageType { get; set; } = null!;

    public string Status { get; set; } = null!;

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Child? Child { get; set; }

    public virtual Guardian? Guardian { get; set; }
}
