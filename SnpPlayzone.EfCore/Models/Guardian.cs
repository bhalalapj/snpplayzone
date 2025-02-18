using System;
using System.Collections.Generic;

namespace SnpPlayzone.EfCore.Models;

public partial class Guardian
{
    public Guid GuardianId { get; set; }

    public string Name { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string? Email { get; set; }

    public string? Address { get; set; }

    public Guid? MembershipId { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<EventManagement> EventManagements { get; set; } = new List<EventManagement>();

    public virtual Membership? Membership { get; set; }

    public virtual ICollection<ParentalEngagement> ParentalEngagements { get; set; } = new List<ParentalEngagement>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual ICollection<VisitHistory> VisitHistories { get; set; } = new List<VisitHistory>();
}
