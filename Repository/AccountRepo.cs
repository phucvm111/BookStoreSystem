using DataAccess;
using DataAccess.Model;
using Repository.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class AccountRepo
    {
        private readonly BookManageContext _context;

        public AccountRepo()
        {
            _context = new BookManageContext();
        }

        // Đăng nhập
        public AccountDTO? GetAccount(string email, string password)
        {
            var acc = _context.Accounts.FirstOrDefault(a => a.EmailAddress == email && a.Password == password);
            if (acc == null) return null;

            return new AccountDTO
            {
                AccountId = acc.AccountId,
                FullName = acc.FullName,
                EmailAddress = acc.EmailAddress,
                Telephone = acc.Telephone,
                Birthday = acc.Birthday, // Không cần ép kiểu
                AccountStatus = acc.AccountStatus,
                Password = acc.Password,
                RoleId = acc.RoleId
            };
        }

        // Lấy danh sách khách hàng
        public List<AccountDTO> GetAllCustomers()
        {
            var customerRoleId = _context.Roles.FirstOrDefault(r => r.RoleName == "Customer")?.RoleId ?? 0;

            return _context.Accounts
                .Where(a => a.RoleId == customerRoleId && a.AccountStatus == 1)
                .Select(a => new AccountDTO
                {
                    AccountId = a.AccountId,
                    FullName = a.FullName,
                    EmailAddress = a.EmailAddress,
                    Telephone = a.Telephone,
                    Birthday = a.Birthday,
                    AccountStatus = a.AccountStatus,
                    Password = a.Password,
                    RoleId = a.RoleId
                }).ToList();
        }

        // Thêm mới
        public void AddCustomer(AccountDTO dto)
        {
            var acc = new Account
            {
                FullName = dto.FullName,
                EmailAddress = dto.EmailAddress,
                Telephone = dto.Telephone,
                Birthday = dto.Birthday,
                AccountStatus = dto.AccountStatus,
                Password = dto.Password,
                RoleId = dto.RoleId
            };
            _context.Accounts.Add(acc);
            _context.SaveChanges();
        }

        // Cập nhật
        public void UpdateCustomer(AccountDTO dto)
        {
            var acc = _context.Accounts.FirstOrDefault(a => a.AccountId == dto.AccountId);
            if (acc != null)
            {
                acc.FullName = dto.FullName;
                acc.EmailAddress = dto.EmailAddress;
                acc.Telephone = dto.Telephone;
                acc.Birthday = dto.Birthday;
                acc.AccountStatus = dto.AccountStatus;
                acc.Password = dto.Password;
                _context.SaveChanges();
            }
        }

        // Xóa
        public void DeleteCustomer(int id)
        {
            var acc = _context.Accounts.FirstOrDefault(a => a.AccountId == id);
            if (acc != null)
            {
                _context.Accounts.Remove(acc);
                _context.SaveChanges();
            }
        }

        // Tìm kiếm
        public List<AccountDTO> SearchCustomers(string keyword)
        {
            var customerRoleId = _context.Roles.FirstOrDefault(r => r.RoleName == "Customer")?.RoleId ?? 0;

            return _context.Accounts
                .Where(a => a.RoleId == customerRoleId &&
                            (a.FullName.Contains(keyword) || a.EmailAddress.Contains(keyword)))
                .Select(a => new AccountDTO
                {
                    AccountId = a.AccountId,
                    FullName = a.FullName,
                    EmailAddress = a.EmailAddress,
                    Telephone = a.Telephone,
                    Birthday = a.Birthday,
                    AccountStatus = a.AccountStatus,
                    Password = a.Password,
                    RoleId = a.RoleId
                }).ToList();
        }
    }
}
