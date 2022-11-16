using System;
using System.Collections.Generic;

namespace ConsoleApp1.Data;

public partial class Photo
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public string Url { get; set; } = null!;

    public bool ShowFirst { get; set; }

    public int AdvertId { get; set; }

    public virtual Advert Advert { get; set; } = null!;
}
