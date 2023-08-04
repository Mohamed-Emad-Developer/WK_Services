using WK_Services.Domain.Core.Commands;
using WK_Services.Domain.Models;

namespace WK_Services.Domain.Commands.ClientCommands
{
    public class ClientCommand : Command
    {
        public int Id { get; set; }
        public Client Client { get; set; }
    }
}
