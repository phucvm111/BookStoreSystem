using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTO
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        public string? CategoryDescription { get; set; }
    }
}
