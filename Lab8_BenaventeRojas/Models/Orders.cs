using System;
using System.Collections.Generic;

namespace Lab8_BenaventeRojas.Models;

public partial class Orders
{
    public int Orderid { get; set; }

    public int Clientid { get; set; }

    public DateTime Orderdate { get; set; }

    public virtual Clients Client { get; set; } = null!;

    public virtual ICollection<Orderdetails> Orderdetails { get; set; } = new List<Orderdetails>();
}
