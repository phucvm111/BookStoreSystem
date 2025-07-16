using DataAccess;
using DataAccess.Model;
using Repository.DTO;

namespace Repository
{
    public class OrderDetailRepo
    {
        private readonly BookManageContext _context;

        public OrderDetailRepo()
        {
            _context = new BookManageContext();
        }

        public List<OrderDetailDTO> GetOrderDetailsByOrderId(int orderId)
        {
            return _context.OrderDetails
                .Where(d => d.OrderId == orderId)
                .Select(d => new OrderDetailDTO
                {
                    OrderDetailId = d.OrderDetailId,
                    OrderId = d.OrderId,
                    BookId = d.BookId,
                    Quantity = d.Quantity,
                    PriceAtOrder = d.PriceAtOrder
                }).ToList();
        }
        public void AddOrderDetail(OrderDetail detail)
        {
            _context.OrderDetails.Add(detail);
            _context.SaveChanges();
        }

        public List<OrderDetail> GetByOrderId(int orderId)
        {
            return _context.OrderDetails
                .Where(d => d.OrderId == orderId)
                .ToList();
        }

    }
}
