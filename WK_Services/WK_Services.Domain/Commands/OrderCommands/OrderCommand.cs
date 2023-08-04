using WK_Services.Domain.Core.Commands;
using WK_Services.Domain.Models;

namespace WK_Services.Domain.Commands.OrderCommands
{
    public class OrderCommand : Command
    {
        public int Id { get; set; }
        public Order Order { get; set; }
    }
}
