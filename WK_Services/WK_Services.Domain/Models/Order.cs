using WK_Services.Domain.Models.BaseEntities;

namespace WK_Services.Domain.Models
{
    public class Order : BaseEnttity
    {
        public OrderType Type { get; set; }
        public int Quantity { get; set; }
        public DateTime? RequestedDeliveryDate { get; set; }
        public int ServiceId { get; set; }
        public int ClientId { get; set; }
        public string OrderNumber { get; set; }
        public Service? Service { get; set; }
        public Client? Client { get; set; }
    }

    public enum OrderType
    {
        Top = 1,
        Sun, 
        Fox
    }
}
