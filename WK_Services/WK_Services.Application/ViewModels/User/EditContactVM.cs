using System.ComponentModel.DataAnnotations;

namespace WK_Services.Application.ViewModels.User
{
    public class EditContactVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [RegularExpression(@"^01[0-2]\d{8}$", ErrorMessage = "Invalid mobile number.")]
        public string Mobile { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
         
    }
}
