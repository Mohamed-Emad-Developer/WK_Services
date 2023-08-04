using MediatR;
using WK_Services.Domain.Commands.ClientCommands;
using WK_Services.Domain.IRepository;

namespace WK_Clients.Domain.CommandHandlers.ClientCommandHandlers
{
    public class CreateClientCommandHandlers : IRequestHandler<CreateClientCommand, bool>
    {
        readonly IClientRepository _clientRepository;

        public CreateClientCommandHandlers(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<bool> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
           return await _clientRepository.Create(request.Client);
        }
    }
}
