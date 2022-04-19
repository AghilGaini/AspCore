using System.Collections.Generic;
using System.Security.Claims;

namespace WebPanel.ViewModels.Permision
{
    public class RolePermisionViewModel
    {
        public RolePermisionViewModel()
        {
            Claims = new List<ClaimInfo>();
        }

        public string RoleId { get; set; }
        public List<ClaimInfo> Claims { get; set; }
    }

    public class ClaimInfo
    {
        public bool IsSelected { get; set; }
        public string Title { get; set; }
    }


}
