using WK_Services.Domain.Core.Commands;
using WK_Services.Domain.Models;

namespace WK_Services.Domain.Commands.ContactCommands
{
    public class ContactCommand : Command
    {
        public int Id { get; set; }
        public Contact Contact { get; set; }
    }
}
