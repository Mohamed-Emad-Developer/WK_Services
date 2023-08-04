using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WK_Services.Domain.Models;

namespace WK_Services.Application.ViewModels
{
    public class OrderTableVM
    {
        public int Id { get; set; }
        public string OrderType { get; set; }
        public int Quantity { get; set; }
        public string? DeliveryDate { get; set; }
        public string ServiceName { get; set; }
        public string ClientName { get; set; }
        public string OrderNumber { get; set; }
    }
}
