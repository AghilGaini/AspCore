using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace WebPanel.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Users = new List<IdentityUser>();
            Actions = new List<ActionItem>()
            {
                 new ActionItem()
                 {
                      Title = "Select"
                 }
            };
        }
        public List<IdentityUser> Users { get; set; }
        public List<ActionItem> Actions { get; set; }
    }
    public class ActionItem
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Route { get; set; }
        public string Title { get; set; }
    }
}
