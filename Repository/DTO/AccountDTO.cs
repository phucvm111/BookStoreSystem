using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTO
{
    public class AccountDTO
    {
        public int AccountId { get; set; }

        public string FullName { get; set; } = null!;

        public string EmailAddress { get; set; } = null!;

        public string? Telephone { get; set; }

        public DateOnly? Birthday { get; set; }

        public int AccountStatus { get; set; }

        public string Password { get; set; } = null!;

        public int RoleId { get; set; }
    }
}
