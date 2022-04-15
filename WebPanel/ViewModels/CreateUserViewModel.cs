using System.ComponentModel.DataAnnotations;

namespace WebPanel.ViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Is Required"), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm 1Password Is Required"),
            DataType(DataType.Password),
            Compare("Password", ErrorMessage = "Confirm Password is not correct")]
        public string ConfirmPassword { get; set; }
    }
}
