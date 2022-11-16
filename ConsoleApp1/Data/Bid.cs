using System;
using System.Collections.Generic;

namespace ConsoleApp1.Data;

public partial class Bid
{
    public int Id { get; set; }

    public decimal Amount { get; set; }

    public DateTime Date { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
