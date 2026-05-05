using System;
using System.Collections.Generic;

namespace Lab8_BenaventeRojas.Models;

public partial class Products
{
    public int Productid { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<Orderdetails> Orderdetails { get; set; } = new List<Orderdetails>();
}
