using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class StatusChange
{
    public int IdChange { get; set; }

    public DateTime? DateChange { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
