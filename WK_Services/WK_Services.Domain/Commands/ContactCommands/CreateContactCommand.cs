using WK_Services.Domain.Models;

namespace WK_Services.Domain.Commands.ContactCommands
{
    public class CreateContactCommand: ContactCommand
    {
        public CreateContactCommand(Contact contact)
        {
            Contact = contact;
        }
    }
}
