using Repository;
using Repository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookManagement
{
    public partial class CustomerWindow : Window
    {
        private readonly AccountDTO _account;
        private readonly AccountRepo _accountRepo = new AccountRepo();
        private readonly OrderRepo _orderRepo = new OrderRepo();
        private readonly BookRepo _bookRepo = new BookRepo();
        private readonly OrderDetailRepo _orderDetailRepo = new OrderDetailRepo();

        private List<BookOrderItem> bookItems = new List<BookOrderItem>();

        public CustomerWindow(AccountDTO account)
        {
            InitializeComponent();
            _account = account;
            LoadProfile();
            LoadOrders();
            LoadShopBooks();
        }

        private void LoadProfile()
        {
            txtName.Text = _account.FullName;
            txtEmail.Text = _account.EmailAddress;
            txtPhone.Text = _account.Telephone;
            dpBirthday.SelectedDate = _account.Birthday?.ToDateTime(new TimeOnly(0, 0));
            txtPassword.Password = _account.Password;
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            _account.FullName = txtName.Text;
            _account.Telephone = txtPhone.Text;
            _account.Birthday = dpBirthday.SelectedDate.HasValue
                ? DateOnly.FromDateTime(dpBirthday.SelectedDate.Value)
                : null;
            _account.Password = txtPassword.Password;

            _accountRepo.UpdateCustomer(_account);
            MessageBox.Show("Profile updated successfully!");
        }

        private void LoadOrders()
        {
            dgOrders.ItemsSource = _orderRepo.GetOrdersByAccountId(_account.AccountId);
        }

        private void LoadShopBooks()
        {
            var books = _bookRepo.GetAllBooks();
            bookItems = books.Select(b => new BookOrderItem { Book = b, Quantity = 0 }).ToList();
            dgShopBooks.ItemsSource = bookItems;
        }

        private void BtnOrderBook_Click(object sender, RoutedEventArgs e)
        {
            var selected = bookItems.Where(b => b.Quantity > 0).ToList();

            if (!selected.Any())
            {
                MessageBox.Show("Please enter quantity for at least one book.");
                return;
            }

            decimal total = selected.Sum(x => x.Quantity * x.Book.Price);

            var orderDto = new OrderDTO
            {
                AccountId = _account.AccountId,
                OrderDate = DateTime.Now,
                TotalAmount = total,
                OrderStatus = "Pending"
            };

            int orderId = _orderRepo.AddOrder(orderDto);

            foreach (var item in selected)
            {
                var detail = new DataAccess.Model.OrderDetail
                {
                    OrderId = orderId,
                    BookId = item.Book.BookId,
                    Quantity = item.Quantity,
                    PriceAtOrder = item.Book.Price
                };
                _orderDetailRepo.AddOrderDetail(detail);
            }

            MessageBox.Show("Order placed successfully!");
            LoadOrders();
            LoadShopBooks();
        }

        public class BookOrderItem
        {
            public BookDTO Book { get; set; } = null!;
            public int Quantity { get; set; }
        }
    }
}
