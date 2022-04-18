using System.Collections.Generic;

namespace WebPanel.ViewModels.Permision
{
    public class RolePermisionViewModel
    {
        public RolePermisionViewModel()
        {
            PermisionInfos = new List<PermisionInfo>();
        }

        public string RoleId { get; set; }
        public List<PermisionInfo> PermisionInfos { get; set; }

    }

    public class PermisionInfo
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public bool IsSelected { get; set; }
    }

}
