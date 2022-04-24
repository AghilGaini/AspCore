using System.Collections.Generic;
using System.Security.Claims;

namespace WebPanel.ViewModels.Permision
{
    public class RolePermisionViewModel
    {
        public RolePermisionViewModel()
        {
            Claims = new List<PermisionInfo>();
        }

        public string RoleId { get; set; }
        public List<PermisionInfo> Claims { get; set; }
    }

    public class PermisionInfo
    {
        public bool IsSelected { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public long PermisionId { get; set; }
    }


}
