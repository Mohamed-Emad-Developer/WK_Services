using System.ComponentModel.DataAnnotations;

namespace WK_Services.Application.ViewModels.User
{
    public class LoginVM
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email address")]
        public string Email { get; set; } 
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Password")]
        public bool RememberPassword { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
