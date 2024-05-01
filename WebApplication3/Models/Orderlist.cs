using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class Orderlist
{
    public int Idorderlist { get; set; }

    public int IdOrder { get; set; }

    public int IdProduct { get; set; }

    public int? Count { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
