using WK_Services.Domain.Models;

namespace WK_Services.Domain.Commands.OrderCommands
{
    public class CreateOrderCommand: OrderCommand
    {
        public CreateOrderCommand(Order order)
        {
            Order = order;
        }
    }
}
