using DataAccess;
using DataAccess.Model;
using Repository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class OrderRepo
    {
        private readonly BookManageContext _context;

        public OrderRepo()
        {
            _context = new BookManageContext();
        }

        // Lấy danh sách đơn hàng của một khách hàng (để dùng trong CustomerWindow)
        public List<OrderDTO> GetOrdersByAccountId(int accountId)
        {
            return _context.Orders
                .Where(o => o.AccountId == accountId)
                .Select(o => new OrderDTO
                {
                    OrderId = o.OrderId,
                    AccountId = o.AccountId,
                    OrderDate = o.OrderDate,
                    TotalAmount = o.TotalAmount,
                    OrderStatus = o.OrderStatus
                })
                .ToList();
        }

        // Báo cáo doanh thu theo khoảng thời gian (dành cho AdminWindow)
        public List<OrderDTO> GetSalesReport(DateTime start, DateTime end)
        {
            return _context.Orders
                .Where(o => o.OrderDate >= start && o.OrderDate <= end)
                .OrderByDescending(o => o.TotalAmount)
                .Select(o => new OrderDTO
                {
                    OrderId = o.OrderId,
                    AccountId = o.AccountId,
                    OrderDate = o.OrderDate,
                    TotalAmount = o.TotalAmount,
                    OrderStatus = o.OrderStatus
                })
                .ToList();
        }
        public int AddOrder(OrderDTO dto)
        {
            var order = new Order
            {
                AccountId = dto.AccountId,
                OrderDate = dto.OrderDate,
                TotalAmount = dto.TotalAmount,
                OrderStatus = dto.OrderStatus
            };
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order.OrderId;
        }

    }
}
