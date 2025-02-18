using System;
using System.Collections.Generic;

namespace SnpPlayzone.EfCore.Models;

public partial class Inventory
{
    public Guid InventoryId { get; set; }

    public string ItemName { get; set; } = null!;

    public int Quantity { get; set; }

    public bool? LowStockAlert { get; set; }

    public DateTime? LastUpdated { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
