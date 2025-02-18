using System;
using System.Collections.Generic;

namespace SnpPlayzone.EfCore.Models;

public partial class Membership
{
    public Guid MembershipId { get; set; }

    public string Type { get; set; } = null!;

    public decimal? Discount { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Child> Children { get; set; } = new List<Child>();

    public virtual ICollection<Guardian> Guardians { get; set; } = new List<Guardian>();
}
