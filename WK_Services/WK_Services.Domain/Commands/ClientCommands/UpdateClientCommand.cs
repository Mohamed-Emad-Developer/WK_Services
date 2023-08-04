using WK_Services.Domain.Models;

namespace WK_Services.Domain.Commands.ClientCommands
{
    public class UpdateClientCommand : ClientCommand
    {
        public UpdateClientCommand(Client client)
        {
            Client = client;
        }
    }
}
