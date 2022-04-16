using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace WebPanel.ViewModels
{
    public class RoleViewModel
    {
        public RoleViewModel()
        {
            Roles = new List<IdentityRole>();
            Actions = new List<ActionItem>()
            {
                 new ActionItem()
                 {
                      Title = "Select"
                 }
            };
        }
        public List<IdentityRole> Roles { get; set; }
        public List<ActionItem> Actions { get; set; }
    }


}
