using System;
using System.Collections.Generic;

namespace ConsoleApp1.Data;

public partial class User
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Street { get; set; } = null!;

    public int PostalCode { get; set; }

    public string City { get; set; } = null!;

    public virtual ICollection<Advert> Adverts { get; } = new List<Advert>();

    public virtual ICollection<Bid> Bids { get; } = new List<Bid>();

    public virtual ICollection<UserHistory> UserHistories { get; } = new List<UserHistory>();
}
