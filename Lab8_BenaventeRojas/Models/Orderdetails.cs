using System;
using System.Collections.Generic;

namespace Lab8_BenaventeRojas.Models;

public partial class Orderdetails
{
    public int Orderdetailid { get; set; }

    public int Orderid { get; set; }

    public int Productid { get; set; }

    public int Quantity { get; set; }

    public virtual Orders Order { get; set; } = null!;

    public virtual Products Product { get; set; } = null!;
}
