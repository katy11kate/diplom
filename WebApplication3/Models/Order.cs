using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public DateOnly DateOrder { get; set; }

    public DateOnly DateDelivery { get; set; }

    public int IdCustomer { get; set; }

    public int StatusOrder { get; set; }

    public int? Warehouse { get; set; }

    public decimal? TotalPrice { get; set; }

    public virtual Customer IdCustomerNavigation { get; set; } = null!;

    public virtual ICollection<Orderlist> Orderlists { get; set; } = new List<Orderlist>();

    public virtual StatusChange StatusOrderNavigation { get; set; } = null!;

    public virtual Warehouse? WarehouseNavigation { get; set; }
}
