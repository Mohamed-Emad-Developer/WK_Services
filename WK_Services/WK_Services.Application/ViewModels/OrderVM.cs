using System.ComponentModel.DataAnnotations;
using WK_Services.Domain.Models;

namespace WK_Services.Application.ViewModels
{
    public class OrderVM
    {
        [Required]
        [Display(Name = "Order Type")]
        public OrderType Type { get; set; }

        [Display(Name = "Service")]
        public int ServiceId { get; set; }

        [Range(minimum: 1, maximum: 5, ErrorMessage = "Quantity must be minimum 1 and 5.")]
        public int Quantity { get; set; }

        [Display(Name = "Requested Delivery Date")]
        public DateTime? RequestedDeliveryDate { get; set; }
    }

    public class OrderResult
    {
        public bool IsSucceeded { get; set; }
        public string? OrderNumber { get; set; }
    }

    public class OrderFilter
    {
        [Display(Name = "Order Type")]
        public OrderType? Type { get; set; }

        [Display(Name = "Service")]
        public int? ServiceId { get; set; }

    }
}
