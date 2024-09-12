using System;
using System.Collections.Generic;

namespace Core.Models;

public partial class Publisher
{
    public int PublisherId { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Website { get; set; }
}
