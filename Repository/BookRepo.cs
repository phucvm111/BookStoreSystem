using DataAccess;
using DataAccess.Model;
using Repository.DTO;

namespace Repository
{
    public class BookRepo
    {
        private readonly BookManageContext _context;

        public BookRepo()
        {
            _context = new BookManageContext();
        }

        public List<BookDTO> GetAllBooks()
        {
            return _context.Books.Select(b => new BookDTO
            {
                BookId = b.BookId,
                BookTitle = b.BookTitle,
                BookDescription = b.BookDescription,
                Author = b.Author,
                StockQuantity = b.StockQuantity,
                BookStatus = b.BookStatus,
                Price = b.Price,
                CategoryId = b.CategoryId
            }).ToList();
        }

        public void AddBook(BookDTO dto)
        {
            var book = new Book
            {
                BookTitle = dto.BookTitle,
                BookDescription = dto.BookDescription,
                Author = dto.Author,
                StockQuantity = dto.StockQuantity,
                BookStatus = dto.BookStatus,
                Price = dto.Price,
                CategoryId = dto.CategoryId
            };
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(BookDTO dto)
        {
            var book = _context.Books.FirstOrDefault(b => b.BookId == dto.BookId);
            if (book != null)
            {
                book.BookTitle = dto.BookTitle;
                book.BookDescription = dto.BookDescription;
                book.Author = dto.Author;
                book.StockQuantity = dto.StockQuantity;
                book.BookStatus = dto.BookStatus;
                book.Price = dto.Price;
                book.CategoryId = dto.CategoryId;
                _context.SaveChanges();
            }
        }

        public void DeleteBook(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.BookId == id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public List<BookDTO> SearchBooks(string keyword)
        {
            return _context.Books
                .Where(b => b.BookTitle.Contains(keyword) || b.Author.Contains(keyword))
                .Select(b => new BookDTO
                {
                    BookId = b.BookId,
                    BookTitle = b.BookTitle,
                    BookDescription = b.BookDescription,
                    Author = b.Author,
                    StockQuantity = b.StockQuantity,
                    BookStatus = b.BookStatus,
                    Price = b.Price,
                    CategoryId = b.CategoryId
                }).ToList();
        }
        public void ReduceStock(int bookId, int quantity)
        {
            var book = _context.Books.FirstOrDefault(b => b.BookId == bookId);
            if (book != null && book.StockQuantity >= quantity)
            {
                book.StockQuantity -= quantity;
                _context.SaveChanges();
            }
        }

    }
}
