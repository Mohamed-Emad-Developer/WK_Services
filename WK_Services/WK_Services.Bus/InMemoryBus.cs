using MediatR;
using WK_Services.Domain.Core.Bus;
using WK_Services.Domain.Core.Commands;

namespace WK_Services.Bus.Bus
{
    public class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<bool> SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }
 

        public Task<IdentityResultViewModel> SendUserCommand<T>(T command) where T : CommandUserService
        {
            return _mediator.Send(command);
        }
    }
}
