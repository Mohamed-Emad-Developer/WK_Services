using MediatR;
using WK_Services.Domain.Commands.ContactCommands;
using WK_Services.Domain.IRepository;

namespace WK_Contacts.Domain.CommandHandlers.ContactCommandHandlers
{
    public class CreateContactCommandHandlers : IRequestHandler<CreateContactCommand, bool>
    {
        readonly IContactRepository _contactRepository;

        public CreateContactCommandHandlers(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<bool> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
           return await _contactRepository.Create(request.Contact);
        }
    }
}
