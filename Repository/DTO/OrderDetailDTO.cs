using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTO
{
    public class OrderDetailDTO
    {
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }

        public int BookId { get; set; }

        public int Quantity { get; set; }

        public decimal PriceAtOrder { get; set; }

    }
}
