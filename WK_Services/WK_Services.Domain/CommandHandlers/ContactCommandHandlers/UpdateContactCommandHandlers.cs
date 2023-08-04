using MediatR;
using WK_Services.Domain.Commands.ContactCommands;
using WK_Services.Domain.IRepository;

namespace WK_Contacts.Domain.CommandHandlers.ContactCommandHandlers
{
    public class UpdateContactCommandHandlers : IRequestHandler<UpdateContactCommand, bool>
    {
        readonly IContactRepository _contactRepository;

        public UpdateContactCommandHandlers(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<bool> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
           return await _contactRepository.Update(request.Contact);
        }
    }
}
