using System;
using System.Collections.Generic;

namespace SnpPlayzone.EfCore.Models;

public partial class Transaction
{
    public Guid TransactionId { get; set; }

    public Guid? GuardianId { get; set; }

    public decimal Amount { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string TransactionType { get; set; } = null!;

    public DateTime? Timestamp { get; set; }

    public string Status { get; set; } = null!;

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Guardian? Guardian { get; set; }

    public virtual ICollection<VisitHistory> VisitHistories { get; set; } = new List<VisitHistory>();
}
