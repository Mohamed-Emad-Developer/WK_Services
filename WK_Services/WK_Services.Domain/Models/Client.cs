using WK_Services.Domain.Models.BaseEntities;

namespace WK_Services.Domain.Models
{
    public class Client : BaseEnttity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? ShipmentAddress { get; set; }
        public ICollection<Contact>? Contacts { get; set; }
        public ICollection<Order>? Orders { get; set; }

    }
}
