using Repository;
using Repository.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BookManagement
{
    public partial class AdminWindow : Window
    {
        private readonly AccountRepo _accountRepo = new AccountRepo();
        private readonly BookRepo _bookRepo = new BookRepo();
        private readonly OrderRepo _orderRepo = new OrderRepo();

        // CONSTRUCTOR KHÔNG ĐỐI SỐ (Constructor mặc định của Window)
        // Đây là constructor mà WPF sẽ gọi khi tạo AdminWindow.
        // Nếu bạn muốn mở AdminWindow mà không truyền bất kỳ dữ liệu nào, hãy dùng nó.
        public AdminWindow()
        {
            InitializeComponent();
            // LoadCustomers() và LoadBooks() được gọi trong Window_Loaded để đảm bảo controls đã sẵn sàng.
        }

        // VÍ DỤ VỀ CONSTRUCTOR CÓ ĐỐI SỐ (BỎ COMMENT PHẦN NÀY NẾU BẠN CẦN TRUYỀN DATA TỪ LoginWindow)
        private readonly AccountDTO? _loggedInUserAccount; // Thêm dấu '?' để cho phép null
        public AdminWindow(AccountDTO loggedInAccount) : this() // Gọi constructor không đối số trước
        {
            _loggedInUserAccount = loggedInAccount; // Gán giá trị được truyền vào
            // Bây giờ bạn có thể sử dụng _loggedInUserAccount trong AdminWindow
            // Ví dụ:
            // this.Title = $"Admin Dashboard - Welcome, {_loggedInUserAccount?.FullName}!";
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCustomers();
            LoadBooks();

            // Thiết lập giá trị mặc định cho DatePicker của Report
            dpStart.SelectedDate = DateTime.Now.AddMonths(-1);
            dpEnd.SelectedDate = DateTime.Now;

            // Gọi LostFocus handler để thiết lập placeholder text ban đầu
            // Truyền một RoutedEventArgs rỗng thay vì null để an toàn hơn
            txtSearch_LostFocus(txtSearchCustomer, new RoutedEventArgs());
            txtSearch_LostFocus(txtSearchBook, new RoutedEventArgs());
        }

        // ---------------------- CUSTOMERS ----------------------

        private void LoadCustomers()
        {
            try
            {
                dgCustomers.ItemsSource = _accountRepo.GetAllCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                // Ghi log ngoại lệ chi tiết hơn: Console.WriteLine(ex.ToString());
            }
        }

        private void BtnSearchCustomer_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtSearchCustomer.Text.Trim();
            if (keyword == "Search by Name or Email...") keyword = "";

            try
            {
                var results = _accountRepo.SearchCustomers(keyword);
                dgCustomers.ItemsSource = results;

                if (results != null && results.Count == 0 && !string.IsNullOrEmpty(keyword))
                {
                    MessageBox.Show("No customers found matching your search criteria.", "Search Result", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching customers: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            // THÊM KIỂM TRA CHO pbCustomerPassword
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text) ||
                string.IsNullOrWhiteSpace(txtCustomerEmail.Text) ||
                string.IsNullOrWhiteSpace(txtCustomerPhone.Text) ||
                string.IsNullOrWhiteSpace(pbCustomerPassword.Password))
            {
                MessageBox.Show("Please fill in Full Name, Email, Phone, and Password.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!txtCustomerEmail.Text.Contains("@") || !txtCustomerEmail.Text.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var dto = new AccountDTO
                {
                    FullName = txtCustomerName.Text.Trim(),
                    EmailAddress = txtCustomerEmail.Text.Trim(),
                    Telephone = txtCustomerPhone.Text.Trim(),
                    Password = pbCustomerPassword.Password, // LẤY MẬT KHẨU TỪ PASSWORDBOX
                    RoleId = 2,
                    AccountStatus = 1,
                    Birthday = dpCustomerBirthday.SelectedDate.HasValue ?
                               DateOnly.FromDateTime(dpCustomerBirthday.SelectedDate.Value) :
                               (DateOnly?)null
                };
                // LƯU Ý: Tại điểm này, bạn NÊN băm (hash) mật khẩu trước khi gửi nó đến repository để lưu vào DB.
                // _accountRepo.AddCustomer(dto); // Sẽ là _accountRepo.AddCustomer(dto);
                _accountRepo.AddCustomer(dto); // Vẫn dùng dto trực tiếp nếu repo của bạn xử lý băm hoặc bạn muốn đơn giản hóa
                MessageBox.Show("Customer added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadCustomers();
                ClearCustomerFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding customer: {ex.Message}\nDetails: {ex.InnerException?.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnUpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomers.SelectedItem is AccountDTO selected)
            {
                if (string.IsNullOrWhiteSpace(txtCustomerName.Text) ||
                    string.IsNullOrWhiteSpace(txtCustomerEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtCustomerPhone.Text))
                {
                    MessageBox.Show("Please fill in Full Name, Email, and Phone for the customer.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (!txtCustomerEmail.Text.Contains("@") || !txtCustomerEmail.Text.Contains("."))
                {
                    MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                try
                {
                    selected.FullName = txtCustomerName.Text.Trim();
                    selected.EmailAddress = txtCustomerEmail.Text.Trim();
                    selected.Telephone = txtCustomerPhone.Text.Trim();
                    selected.Birthday = dpCustomerBirthday.SelectedDate.HasValue ?
                                        DateOnly.FromDateTime(dpCustomerBirthday.SelectedDate.Value) :
                                        (DateOnly?)null;

                    // CHỈ CẬP NHẬT MẬT KHẨU NẾU PASSWORDBOX KHÔNG TRỐNG
                    if (!string.IsNullOrWhiteSpace(pbCustomerPassword.Password))
                    {
                        selected.Password = pbCustomerPassword.Password; // LẤY MẬT KHẨU MỚI
                        // LƯU Ý: Tại điểm này, bạn NÊN băm (hash) mật khẩu trước khi gửi nó đến repository để lưu vào DB.
                    }

                    _accountRepo.UpdateCustomer(selected);
                    MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadCustomers();
                    ClearCustomerFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating customer: {ex.Message}\nDetails: {ex.InnerException?.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to update.", "Selection Required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomers.SelectedItem is AccountDTO selected)
            {
                MessageBoxResult confirm = MessageBox.Show($"Are you sure you want to delete customer '{selected.FullName}' (ID: {selected.AccountId})?",
                                                          "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirm == MessageBoxResult.Yes)
                {
                    try
                    {
                        _accountRepo.DeleteCustomer(selected.AccountId);
                        MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadCustomers();
                        ClearCustomerFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting customer: {ex.Message}\nDetails: {ex.InnerException?.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.", "Selection Required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void dgCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgCustomers.SelectedItem is AccountDTO selected)
            {
                txtCustomerName.Text = selected.FullName ?? "";
                txtCustomerEmail.Text = selected.EmailAddress ?? "";
                txtCustomerPhone.Text = selected.Telephone ?? "";
                dpCustomerBirthday.SelectedDate = selected.Birthday?.ToDateTime(TimeOnly.MinValue);
                pbCustomerPassword.Password = ""; // LUÔN ĐẶT TRỐNG: KHÔNG HIỂN THỊ MẬT KHẨU CŨ VÌ LÝ DO BẢO MẬT
            }
            else
            {
                ClearCustomerFields();
            }
        }

        private void BtnClearCustomerFields_Click(object sender, RoutedEventArgs e)
        {
            ClearCustomerFields();
            dgCustomers.SelectedItem = null; // Bỏ chọn hàng trong DataGrid
            txtSearch_LostFocus(txtSearchCustomer, new RoutedEventArgs()); // Đặt lại placeholder cho search box
        }

        private void BtnShowAllCustomers_Click(object sender, RoutedEventArgs e)
        {
            txtSearchCustomer.Text = "Search by Name or Email..."; // Reset search box text
            txtSearchCustomer.Foreground = Brushes.Gray; // Reset text color
            LoadCustomers(); // Tải lại toàn bộ danh sách khách hàng
        }

        private void ClearCustomerFields()
        {
            txtCustomerName.Text = "";
            txtCustomerEmail.Text = "";
            txtCustomerPhone.Text = "";
            dpCustomerBirthday.SelectedDate = null;
            pbCustomerPassword.Password = ""; // LÀM SẠCH TRƯỜNG MẬT KHẨU
        }

        // ---------------------- BOOKS ----------------------

        private void LoadBooks()
        {
            try
            {
                dgBooks.ItemsSource = _bookRepo.GetAllBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading books: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnSearchBook_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtSearchBook.Text.Trim();
            if (keyword == "Search by Title or Author...") keyword = "";

            try
            {
                var results = _bookRepo.SearchBooks(keyword);
                dgBooks.ItemsSource = results;

                if (results != null && results.Count == 0 && !string.IsNullOrEmpty(keyword))
                {
                    MessageBox.Show("No books found matching your search criteria.", "Search Result", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching books: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAddBook_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBookTitle.Text) ||
                string.IsNullOrWhiteSpace(txtBookAuthor.Text) ||
                !int.TryParse(txtBookStock.Text, out int qty) || qty < 0 ||
                !decimal.TryParse(txtBookPrice.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price) || price < 0)
            {
                MessageBox.Show("Please enter valid Book Title, Author, a non-negative Stock, and a non-negative Price.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var dto = new BookDTO
                {
                    BookTitle = txtBookTitle.Text.Trim(),
                    Author = txtBookAuthor.Text.Trim(),
                    StockQuantity = qty,
                    Price = price,
                    BookStatus = 1, // Default status
                    CategoryId = 1 // Placeholder - consider allowing selection via ComboBox
                };
                _bookRepo.AddBook(dto);
                MessageBox.Show("Book added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadBooks();
                ClearBookFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding book: {ex.Message}\nDetails: {ex.InnerException?.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnUpdateBook_Click(object sender, RoutedEventArgs e)
        {
            if (dgBooks.SelectedItem is BookDTO selected)
            {
                if (string.IsNullOrWhiteSpace(txtBookTitle.Text) ||
                    string.IsNullOrWhiteSpace(txtBookAuthor.Text) ||
                    !int.TryParse(txtBookStock.Text, out int qty) || qty < 0 ||
                    !decimal.TryParse(txtBookPrice.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price) || price < 0)
                {
                    MessageBox.Show("Please enter valid Book Title, Author, a non-negative Stock, and a non-negative Price.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                try
                {
                    selected.BookTitle = txtBookTitle.Text.Trim();
                    selected.Author = txtBookAuthor.Text.Trim();
                    selected.StockQuantity = qty;
                    selected.Price = price;

                    _bookRepo.UpdateBook(selected);
                    MessageBox.Show("Book updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadBooks();
                    ClearBookFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating book: {ex.Message}\nDetails: {ex.InnerException?.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a book to update.", "Selection Required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnDeleteBook_Click(object sender, RoutedEventArgs e)
        {
            if (dgBooks.SelectedItem is BookDTO selected)
            {
                MessageBoxResult confirm = MessageBox.Show($"Are you sure you want to delete book '{selected.BookTitle}' (ID: {selected.BookId})?",
                                                          "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirm == MessageBoxResult.Yes)
                {
                    try
                    {
                        _bookRepo.DeleteBook(selected.BookId);
                        MessageBox.Show("Book deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadBooks();
                        ClearBookFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting book: {ex.Message}\nDetails: {ex.InnerException?.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a book to delete.", "Selection Required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void dgBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgBooks.SelectedItem is BookDTO selected)
            {
                txtBookTitle.Text = selected.BookTitle ?? "";
                txtBookAuthor.Text = selected.Author ?? "";
                txtBookStock.Text = selected.StockQuantity.ToString();
                txtBookPrice.Text = selected.Price.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                ClearBookFields();
            }
        }

        private void BtnClearBookFields_Click(object sender, RoutedEventArgs e)
        {
            ClearBookFields();
            dgBooks.SelectedItem = null;
            txtSearch_LostFocus(txtSearchBook, new RoutedEventArgs()); // Đặt lại placeholder cho search box
        }

        private void BtnShowAllBooks_Click(object sender, RoutedEventArgs e)
        {
            txtSearchBook.Text = "Search by Title or Author..."; // Reset search box text
            txtSearchBook.Foreground = Brushes.Gray; // Reset text color
            LoadBooks(); // Tải lại toàn bộ danh sách sách
        }

        private void ClearBookFields()
        {
            txtBookTitle.Text = "";
            txtBookAuthor.Text = "";
            txtBookStock.Text = "";
            txtBookPrice.Text = "";
        }

        // ---------------------- REPORT ----------------------

        private void GenerateReport_Click(object sender, RoutedEventArgs e)
        {
            if (!dpStart.SelectedDate.HasValue || !dpEnd.SelectedDate.HasValue)
            {
                MessageBox.Show("Please select both start and end dates for the report.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DateTime startDate = dpStart.SelectedDate.Value;
            DateTime endDate = dpEnd.SelectedDate.Value.Date.AddDays(1).AddSeconds(-1);

            if (startDate > endDate)
            {
                MessageBox.Show("Start date cannot be after end date.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var result = _orderRepo.GetSalesReport(startDate, endDate);
                dgReport.ItemsSource = result;

                if (result == null || result.Count == 0)
                {
                    MessageBox.Show("No sales data found for the selected date range.", "Report Result", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}\nDetails: {ex.InnerException?.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // ---------------------- COMMON UI LOGIC ----------------------

        private void txtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text == "Search by Name or Email..." || tb.Text == "Search by Title or Author...")
                {
                    tb.Text = "";
                    tb.Foreground = Brushes.Black;
                }
            }
        }

        private void txtSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb && string.IsNullOrWhiteSpace(tb.Text))
            {
                if (tb.Name == "txtSearchCustomer")
                    tb.Text = "Search by Name or Email...";
                else if (tb.Name == "txtSearchBook")
                    tb.Text = "Search by Title or Author...";

                tb.Foreground = Brushes.Gray;
            }
        }
    }
}