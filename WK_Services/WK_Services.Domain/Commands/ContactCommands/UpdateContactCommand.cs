using WK_Services.Domain.Models;

namespace WK_Services.Domain.Commands.ContactCommands
{
    public class UpdateContactCommand : ContactCommand
    {
        public UpdateContactCommand(Contact contact)
        {
            Contact = contact;
        }
    }
}
