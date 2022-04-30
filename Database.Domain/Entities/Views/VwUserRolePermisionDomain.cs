using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.Entities.Views
{
    public class VwUserRolePermisionDomain
    {
        public string userId { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
        public string roleId { get; set; }
        public string roleName { get; set; }
        //public string PermisionTitle { get; set; }
        public long permisionId { get; set; }
        public string PermisionValue { get; set; }
    }
}
