using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class Warehouse
{
    public int IdWarehouse { get; set; }

    public string? WarehouseName { get; set; }

    public string? Adress { get; set; }

    public virtual ICollection<Consignment> Consignments { get; set; } = new List<Consignment>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<ProductAvailability> ProductAvailabilities { get; set; } = new List<ProductAvailability>();
}
