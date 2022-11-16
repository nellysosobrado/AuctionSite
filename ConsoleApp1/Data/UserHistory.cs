using System;
using System.Collections.Generic;

namespace ConsoleApp1.Data;

public partial class UserHistory
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string IpAddress { get; set; } = null!;

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
