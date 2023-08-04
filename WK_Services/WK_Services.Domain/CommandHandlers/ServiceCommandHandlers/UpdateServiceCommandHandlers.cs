using MediatR;
using WK_Services.Domain.Commands.ServiceCommands;
using WK_Services.Domain.IRepository;

namespace WK_Services.Domain.CommandHandlers.ServiceCommandHandlers
{
    public class UpdateServiceCommandHandlers : IRequestHandler<UpdateServiceCommand, bool>
    {
        readonly IServiceRepository _serviceRepository;

        public UpdateServiceCommandHandlers(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<bool> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
           return await _serviceRepository.Update(request.Service);
        }
    }
}
