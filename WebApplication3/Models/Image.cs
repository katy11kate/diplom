using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class Image
{
    public int IdImage { get; set; }

    public int? IdProduct { get; set; }

    public string? RouteImage { get; set; }

    public virtual Product? IdProductNavigation { get; set; }
}
