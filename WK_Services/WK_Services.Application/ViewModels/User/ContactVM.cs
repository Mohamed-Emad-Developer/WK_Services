using System.ComponentModel.DataAnnotations;

namespace WK_Services.Application.ViewModels.User
{
    public class ContactVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [RegularExpression(@"^01[0-2]\d{8}$", ErrorMessage = "Invalid mobile number.")]
        public string Mobile { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string UserName { get; set; }
        public int ClientId { get; set; }
         
    }
}
