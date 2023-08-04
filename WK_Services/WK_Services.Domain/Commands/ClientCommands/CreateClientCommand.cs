using WK_Services.Domain.Models;

namespace WK_Services.Domain.Commands.ClientCommands
{
    public class CreateClientCommand: ClientCommand
    {
        public CreateClientCommand(Client client)
        {
            Client = client;
        }
    }
}
