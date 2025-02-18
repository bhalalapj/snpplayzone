using System;
using System.Collections.Generic;

namespace SnpPlayzone.EfCore.Models;

public partial class ParentalEngagement
{
    public Guid EngagementId { get; set; }

    public Guid? GuardianId { get; set; }

    public string MessageType { get; set; } = null!;

    public string MessageContent { get; set; } = null!;

    public DateTime? Timestamp { get; set; }

    public string Status { get; set; } = null!;

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Guardian? Guardian { get; set; }
}
