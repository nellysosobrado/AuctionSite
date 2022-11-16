using System;
using System.Collections.Generic;

namespace ConsoleApp1.Data;

public partial class Advert
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal StartingPrice { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Photo> Photos { get; } = new List<Photo>();

    public virtual User User { get; set; } = null!;
}
