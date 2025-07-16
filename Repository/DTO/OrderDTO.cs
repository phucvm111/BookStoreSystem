using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }

        public int AccountId { get; set; }

        public DateTime? OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string OrderStatus { get; set; } = null!;
    }
}
