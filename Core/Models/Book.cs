using System;
using System.Collections.Generic;

namespace Core.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsExpert { get; set; }

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Author> Authors { get; set; } = new List<Author>();

}


