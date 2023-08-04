using MediatR;
using WK_Services.Domain.Commands.ClientCommands;
using WK_Services.Domain.IRepository;

namespace WK_Clients.Domain.CommandHandlers.ClientCommandHandlers
{
    public class UpdateClientCommandHandlers : IRequestHandler<UpdateClientCommand, bool>
    {
        readonly IClientRepository _clientRepository;

        public UpdateClientCommandHandlers(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<bool> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
           return await _clientRepository.Update(request.Client);
        }
    }
}
