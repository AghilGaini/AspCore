using System.Collections.Generic;

namespace WebPanel.ViewModels
{
    public class UserRoleViewModel
    {
        public UserRoleViewModel()
        {
            rolesInfo = new List<RoleInfoViewModel>();
        }
        public string userId { get; set; }
        public List<RoleInfoViewModel> rolesInfo { get; set; }
    }

    public class RoleInfoViewModel
    {
        public string RoleID { get; set; }
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }
    }
}
