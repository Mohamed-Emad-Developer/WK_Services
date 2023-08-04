using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WK_Services.Application.Interfaces;
using WK_Services.Domain.Commands.ServiceCommands;
using WK_Services.Domain.Core.Bus;
using WK_Services.Domain.IRepository;
using WK_Services.Domain.Models;

namespace WK_Services.Application.Services
{
    public class ServiceService : IServiceService
    {
        readonly IMediatorHandler _bus;
        readonly IServiceRepository _serviceRepository;

        public ServiceService(IMediatorHandler bus, IServiceRepository serviceRepository)
        {
            _bus = bus;
            _serviceRepository = serviceRepository;
        }

        public async Task<bool> Create(Service service)
        {
            var createServiceCommand = new CreateServiceCommand(service);
            var result = await _bus.SendCommand(createServiceCommand);
            return result;
        }

        public async Task<Service?> Get(int id)
        {
            return await _serviceRepository.Get(id);
        }

        public async Task<IEnumerable<Service>> GetAll()
        {
            return await _serviceRepository.GetAll();
        }

        public async Task<bool> Update(Service service)
        {
            var updateServiceCommand = new UpdateServiceCommand(service);
            var result = await _bus.SendCommand(updateServiceCommand);
            return result;
        }
        public async Task<bool> CheckNameExist(string name, int? id = null)
        {
            name = name.Trim().ToLower();
            return await _serviceRepository.GetAllQueryable(c => c.Name.ToLower().Contains(name) && (id == null || c.Id != id)).AnyAsync();
        }

        public async Task<SelectList> GetSelectList()
        {
            var servicesData = await _serviceRepository.GetAllQueryable().Select(c => new { c.Id, c.Name }).ToListAsync();
            return new SelectList(servicesData,"Id", "Name");
        }
    }
}
