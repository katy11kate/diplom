using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class Provider
{
    public int IdProvider { get; set; }

    public string NameOrganization { get; set; } = null!;

    public string Telophone { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public virtual ICollection<Consignment> Consignments { get; set; } = new List<Consignment>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
