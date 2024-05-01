using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class Customer
{
    public int IdCustomer { get; set; }

    public string? Firstname { get; set; }

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public DateOnly? Birthdate { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Basket> Baskets { get; set; } = new List<Basket>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
