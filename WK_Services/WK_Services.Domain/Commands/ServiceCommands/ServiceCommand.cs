using WK_Services.Domain.Core.Commands;
using WK_Services.Domain.Models;

namespace WK_Services.Domain.Commands.ServiceCommands
{
    public class ServiceCommand : Command
    {
        public int Id { get; set; }
        public Service Service { get; set; }
    }
}
