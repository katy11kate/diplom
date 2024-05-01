using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class Consignment
{
    public int IdConsignment { get; set; }

    public int? IdProvider { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public int? ResponsibleEmployee { get; set; }

    public int? Warehouse { get; set; }

    public virtual ICollection<Consignmentlist> Consignmentlists { get; set; } = new List<Consignmentlist>();

    public virtual Provider? IdProviderNavigation { get; set; }

    public virtual Employee? ResponsibleEmployeeNavigation { get; set; }

    public virtual Warehouse? WarehouseNavigation { get; set; }
}
