using Database.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.Interfaces
{
    public interface IRolePermisionRepository : IGenericRepository<RolePermisionDomain>
    {
        List<RolePermisionDomain> GetByRoleId(string roleId);

    }
}
