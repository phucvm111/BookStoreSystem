using System;
using System.Collections.Generic;

namespace DataAccess.Model;

public partial class Book
{
    public int BookId { get; set; }

    public string BookTitle { get; set; } = null!;

    public string? BookDescription { get; set; }

    public string? Author { get; set; }

    public int StockQuantity { get; set; }

    public int BookStatus { get; set; }

    public decimal Price { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
