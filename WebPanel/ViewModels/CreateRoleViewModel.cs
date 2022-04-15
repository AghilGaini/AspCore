using System.ComponentModel.DataAnnotations;

namespace WebPanel.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required(ErrorMessage = "Name Is Required")]
        public string RoleName { get; set; }
    }
}
