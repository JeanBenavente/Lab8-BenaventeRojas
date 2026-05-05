using System;
using System.Collections.Generic;

namespace Lab8_BenaventeRojas.Models;

public partial class Clients
{
    public int Clientid { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();
}
