using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTO
{
    public class BookDTO
    {
        public int BookId { get; set; }

        public string BookTitle { get; set; } = null!;

        public string? BookDescription { get; set; }

        public string? Author { get; set; }

        public int StockQuantity { get; set; }

        public int BookStatus { get; set; }

        public decimal Price { get; set; }

        public int? CategoryId { get; set; }
    }
}
