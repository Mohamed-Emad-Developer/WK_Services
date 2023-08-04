using WK_Services.Domain.Models;

namespace WK_Services.Domain.Commands.ServiceCommands
{
    public class UpdateServiceCommand : ServiceCommand
    {
        public UpdateServiceCommand(Service service)
        {
            Service = service;
        }
    }
}
