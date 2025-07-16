using System;
using System.Collections.Generic;

namespace DataAccess.Model;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }

    public int BookId { get; set; }

    public int Quantity { get; set; }

    public decimal PriceAtOrder { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
