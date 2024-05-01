using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class ProductAvailability
{
    public int IdProduct { get; set; }

    public int? QuantityInStock { get; set; }

    public int? IdWarehouse { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual Warehouse? IdWarehouseNavigation { get; set; }
}
