using MediatR;
using WK_Services.Domain.Commands.OrderCommands;
using WK_Services.Domain.IRepository;

namespace WK_Services.Domain.CommandHandlers.OrderCommandHandlers
{
    public class CreateOrderCommandHandlers : IRequestHandler<CreateOrderCommand, bool>
    {
        readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandlers(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
           return await _orderRepository.Create(request.Order);
        }
    }
}
