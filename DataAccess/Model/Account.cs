using System;
using System.Collections.Generic;

namespace DataAccess.Model;

public partial class Account
{
    public int AccountId { get; set; }

    public string FullName { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public string? Telephone { get; set; }

    public DateOnly? Birthday { get; set; }

    public int AccountStatus { get; set; }

    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role Role { get; set; } = null!;
}
