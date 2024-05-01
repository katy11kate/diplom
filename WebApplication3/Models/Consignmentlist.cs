using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class Consignmentlist
{
    public int IdConsignmentlist { get; set; }

    public int IdConsignmen { get; set; }

    public int IdProduct { get; set; }

    public int? Count { get; set; }

    public virtual Consignment IdConsignmenNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
