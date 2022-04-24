using Database.Domain.Entities;
using Database.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.EFCore.Repositories
{
    public class RolePermisionRepository : GenericRepository<RolePermisionDomain>, IRolePermisionRepository
    {
        private readonly ApplicationContext _context;

        public RolePermisionRepository(ApplicationContext context) : base(context)
        {
            this._context = context;
        }

        public List<RolePermisionDomain> GetByRoleId(string roleId)
        {
            return _context.RolePermisions.Where(x => x.RoleId == roleId).ToList();
        }

        public List<RolePermisionDomain> GetByRoleIds(List<string> roleIds)
        {
            return _context.RolePermisions.Where(r => roleIds.Any(x => x == r.RoleId)).ToList();
        }
    }
}
