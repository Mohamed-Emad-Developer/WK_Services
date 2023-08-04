using MediatR;
using WK_Services.Domain.Commands.ServiceCommands;
using WK_Services.Domain.IRepository;

namespace WK_Services.Domain.CommandHandlers.ServiceCommandHandlers
{
    public class CreateServiceCommandHandlers : IRequestHandler<CreateServiceCommand, bool>
    {
        readonly IServiceRepository _serviceRepository;

        public CreateServiceCommandHandlers(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<bool> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
           return await _serviceRepository.Create(request.Service);
        }
    }
}
