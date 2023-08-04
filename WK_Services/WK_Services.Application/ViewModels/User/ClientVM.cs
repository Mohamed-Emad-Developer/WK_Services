using System.ComponentModel.DataAnnotations;

namespace WK_Services.Application.ViewModels.User
{
    public class ClientVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [RegularExpression(@"^01[0-2]\d{8}$", ErrorMessage = "Invalid mobile number.")]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

 
        public string? Country { get; set; }
        public string? City { get; set; }

        [Display(Name = "Shipment Address")]
        public string? ShipmentAddress { get; set; }
    }
}
