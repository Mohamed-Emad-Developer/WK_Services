using WK_Services.Domain.Models;

namespace WK_Services.Domain.Commands.ServiceCommands
{
    public class CreateServiceCommand: ServiceCommand
    {
        public CreateServiceCommand(Service service)
        {
            Service = service;
        }
    }
}
