﻿using System;
using System.Collections.Generic;

namespace DataAccess.Model;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? CategoryDescription { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
