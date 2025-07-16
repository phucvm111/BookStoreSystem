﻿using System;
using System.Collections.Generic;

namespace DataAccess.Model;

public partial class Order
{
    public int OrderId { get; set; }

    public int AccountId { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    public string OrderStatus { get; set; } = null!;

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
