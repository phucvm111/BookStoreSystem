using DataAccess;
using DataAccess.Model;
using Repository.DTO;

namespace Repository
{
    public class CategoryRepo
    {
        private readonly BookManageContext _context;

        public CategoryRepo()
        {
            _context = new BookManageContext();
        }

        public List<CategoryDTO> GetAllCategories()
        {
            return _context.Categories.Select(c => new CategoryDTO
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                CategoryDescription = c.CategoryDescription
            }).ToList();
        }
    }
}
