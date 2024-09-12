﻿using System;
using System.Collections.Generic;

namespace Core.Models;

public partial class Author
{
    public int AuthorId { get; set; }

    public string Name { get; set; } = null!;

    public string? Bio { get; set; }

    public bool? IsExpert { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
