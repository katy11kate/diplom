using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class Employee
{
    public int IdEmployee { get; set; }

    public string Firstname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string Post { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Consignment> Consignments { get; set; } = new List<Consignment>();
}
