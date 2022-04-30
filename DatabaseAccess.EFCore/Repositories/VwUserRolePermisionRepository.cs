using Database.Domain.Entities.Views;
using Database.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace DatabaseAccess.EFCore.Repositories
{
    public class VwUserRolePermisionRepository : GenericRepository<VwUserRolePermisionDomain>, IVwUserRolePermisionRepository
    {
        private readonly ApplicationContext _context;

        public VwUserRolePermisionRepository(ApplicationContext context) : base(context)
        {
            this._context = context;
        }

        public bool HasUserPermision(string userName, string permision)
        {
            var user = _context.Users.FirstOrDefault(r => r.UserName == userName);
            if (user == null)
                return false;

            if (user.IsAdmin)
                return true;

            return _context.VwUserRolePermision.Any(r => r.UserName == userName && r.PermisionValue == permision);

        }
    }
}
