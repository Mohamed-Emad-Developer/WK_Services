using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WK_Services.Application.Interfaces;
using WK_Services.Application.ViewModels.FatatableViewModels;
using WK_Services.Application.ViewModels.User;
using WK_Services.Domain.Commands.ClientCommands;
using WK_Services.Domain.Core.Bus;
using WK_Services.Domain.IRepository;
using WK_Services.Domain.Models;

namespace WK_Services.Application.Services
{
    public class ClientService : IClientService
    {
        readonly IMediatorHandler _bus;
        readonly IClientRepository _clientRepository;
        readonly IMapper _mapper;

        public ClientService(IMediatorHandler bus, IClientRepository clientRepository, IMapper mapper)
        {
            _bus = bus;
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<bool> Create(ClientVM ClientVM)
        {
            var client = _mapper.Map<Client>(ClientVM);
            client.CreatedDateOnUtc = DateTime.UtcNow;
            client.UpdatedDateOnUtc = DateTime.UtcNow;
            var createClientCommand = new CreateClientCommand(client);
            var result = await _bus.SendCommand(createClientCommand);
            return result;
        }

        public async Task<Client?> Get(int id)
        {
            return await _clientRepository.Get(id);
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _clientRepository.GetAll();
        }

        public async Task<bool> Update(ClientVM ClientVM)
        {
  
            var client = await Get(ClientVM.Id);
            if (client == null)
                return false;

            client.Name = ClientVM.Name;
            client.Phone = ClientVM.Phone;
            client.Email = ClientVM.Email;
            client.City = ClientVM.City;
            client.Country = ClientVM.Country;
            client.ShipmentAddress = ClientVM.ShipmentAddress;
            client.UpdatedDateOnUtc = DateTime.UtcNow;
            var updateClientCommand = new UpdateClientCommand(client);
            var result = await _bus.SendCommand(updateClientCommand);
            return result;
        }

        public async Task<ClientVM?> GetClientVM(int id)
        {
            return await _clientRepository.GetAllQueryable(c => c.Id == id).ProjectTo<ClientVM>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();

        }

        public async Task<DataTableVM<ClientVM>> GetClientVMDataTableVM(int? take= null, int? skip = null)
        {
            var result = new DataTableVM<ClientVM>();
            var query =   _clientRepository.GetAllQueryable().ProjectTo<ClientVM>(_mapper.ConfigurationProvider);

            result.Data = await query.Skip(skip ?? 0).Take(take ?? 10).ToListAsync();
            result.RecordsFiltered = result.Data.Count();
            result.RecordsTotal = await query.Select(c => c.Id).CountAsync();
            return result;
        }

    }
}
