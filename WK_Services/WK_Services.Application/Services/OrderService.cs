using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WK_Services.Application.Interfaces;
using WK_Services.Application.ViewModels;
using WK_Services.Application.ViewModels.FatatableViewModels;
using WK_Services.Domain.Commands.OrderCommands;
using WK_Services.Domain.Core.Bus;
using WK_Services.Domain.IRepository;
using WK_Services.Domain.Models;

namespace WK_Services.Application.Services
{
    public class OrderService : IOrderService
    {
        readonly IMediatorHandler _bus;
        readonly IMapper _mapper;
        readonly IContactService _contactService;
        readonly IOrderRepository _orderRepository;

        public OrderService(IMediatorHandler bus, IMapper mapper, IContactService contactService, IOrderRepository orderRepository)
        {
            _bus = bus;
            _mapper = mapper;
            _contactService = contactService;
            _orderRepository = orderRepository;
        }

        public async Task<OrderResult> Create(OrderVM orderVm, string contactUserId)
        {
            var orderResult = new OrderResult();
            var order = _mapper.Map<Order>(orderVm);
            var clientData = await _contactService.GetClientIdByContactUserId(contactUserId);
            order.ClientId = clientData.Id;
            var serial = await _orderRepository.GetAll(c => c.ClientId == clientData.Id).CountAsync();
            order.OrderNumber = $"{clientData.Name}_{DateTime.Now.ToString()}_{serial + 1}";
            order.CreatedDateOnUtc = DateTime.UtcNow;
            order.UpdatedDateOnUtc = DateTime.UtcNow;

            var createOrderCommand = new CreateOrderCommand(order);
            var result = await _bus.SendCommand(createOrderCommand);
            if (result)
            {
                orderResult.IsSucceeded = true;
                orderResult.OrderNumber = order.OrderNumber;
                return orderResult;
            }
            return orderResult;
        }

        public async Task<DataTableVM<OrderTableVM>> GetOrderVMDataTableVM(OrderFilter filter, int? clientId = null, int? take = null, int? skip = null)
        {
            var result = new DataTableVM<OrderTableVM>();
            var query = _orderRepository.GetAll(c => (clientId == null || c.ClientId == clientId.Value)
            && (filter.Type == null || c.Type == filter.Type.Value)
            && (filter.ServiceId == null || c.ServiceId == filter.ServiceId.Value)
            ).ProjectTo<OrderTableVM>(_mapper.ConfigurationProvider);

            result.Data = await query.Skip(skip ?? 0).Take(take ?? 10).ToListAsync();
            result.RecordsFiltered = result.Data.Count();
            result.RecordsTotal = await query.Select(c => c.Id).CountAsync();
            return result;
        }
    }
}
