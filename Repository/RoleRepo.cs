using DataAccess;
using DataAccess.Model;
using Repository.DTO;

namespace Repository
{
    public class RoleRepo
    {
        private readonly BookManageContext _context;

        public RoleRepo()
        {
            _context = new BookManageContext();
        }

        public string GetRoleNameById(int id)
        {
            return _context.Roles.FirstOrDefault(r => r.RoleId == id)?.RoleName ?? "";
        }
    }
}
