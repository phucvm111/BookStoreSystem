using Repository;
using Repository.DTO;
using System.Windows;

namespace BookManagement
{
    public partial class LoginWindow : Window
    {
        private readonly AccountRepo _repo = new AccountRepo();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Password.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            AccountDTO? acc = _repo.GetAccount(email, password); // acc có thể là null
            if (acc == null)
            {
                MessageBox.Show("Invalid email or password!", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (acc.RoleId == 1)
            {
                // Admin
                var adminWin = new AdminWindow(); // SỬA ĐỔI TẠI ĐÂY: KHÔNG TRUYỀN ĐỐI SỐ
                adminWin.Show();
            }
            else if (acc.RoleId == 2)
            {
                // Customer
                // Kiểm tra customerWin cũng có constructor không đối số, nếu không cũng sẽ lỗi tương tự
                var customerWin = new CustomerWindow(acc);
                customerWin.Show();
            }

            this.Close();
        }
    }
}