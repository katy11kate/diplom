using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class Basket
{
    public int? IdCustomer { get; set; }

    public int IdProduct { get; set; }

    public int Quantity { get; set; }

    public int IdBasket { get; set; }

    public virtual Customer? IdCustomerNavigation { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;
}
