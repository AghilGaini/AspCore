using System.Collections.Generic;

namespace WebPanel.ViewModels
{
    public class RoleUserViewModel
    {
        public RoleUserViewModel()
        {
            UserInfo = new List<UserInfoModel>();
        }
        public List<UserInfoModel> UserInfo { get; set; }
        public string RoleId { get; set; }
    }

    public class UserInfoModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public bool IsSelected { get; set; }
    }
}
