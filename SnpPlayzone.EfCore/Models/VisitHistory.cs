using System;
using System.Collections.Generic;

namespace SnpPlayzone.EfCore.Models;

public partial class VisitHistory
{
    public Guid VisitId { get; set; }

    public Guid? ChildId { get; set; }

    public Guid? GuardianId { get; set; }

    public DateTime CheckInTime { get; set; }

    public DateTime? CheckOutTime { get; set; }

    public string? EntryType { get; set; }

    public Guid? PaymentId { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Child? Child { get; set; }

    public virtual Guardian? Guardian { get; set; }

    public virtual Transaction? Payment { get; set; }
}
