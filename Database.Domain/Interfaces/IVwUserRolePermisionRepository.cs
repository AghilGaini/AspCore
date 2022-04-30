using Database.Domain.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.Interfaces
{
    public interface IVwUserRolePermisionRepository : IGenericRepository<VwUserRolePermisionDomain>
    {
        bool HasUserPermision(string userId, string permision);
    }
}
