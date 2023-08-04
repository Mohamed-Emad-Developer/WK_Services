using Microsoft.AspNetCore.Mvc.Rendering;
using WK_Services.Application.ViewModels.FatatableViewModels;
using WK_Services.Application.ViewModels.User;
using WK_Services.Domain.Models;

namespace WK_Services.Application.Interfaces
{
    public interface IClientService
    {
        Task<bool> Create(ClientVM ClientVM);
        Task<Client?> Get(int id);
        Task<IEnumerable<Client>> GetAll();
        Task<bool> Update(ClientVM ClientVM);
        Task<ClientVM?> GetClientVM(int id);
        Task<DataTableVM<ClientVM>> GetClientVMDataTableVM(int? take = null, int? skip = null);
    }
}
