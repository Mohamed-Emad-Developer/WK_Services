using WK_Services.Domain.Models.BaseEntities;
using WK_Services.Domain.Models.User;

namespace WK_Services.Domain.Models
{
    public class Contact : BaseEnttity
    {
        public string Mobile { get; set; }
        public string UserId { get; set; }
        public int ClientId { get; set; }
        public ApplicationUser? User { get; set; }
        public Client? Client { get; set; }
    }
}
