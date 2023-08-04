using Microsoft.AspNetCore.Mvc.Rendering;
using WK_Services.Domain.Models;

namespace WK_Services.Application.Interfaces
{
    public interface IServiceService
    {
        Task<bool> Create(Service service);
        Task<bool> Update(Service service);
        Task<Service?> Get(int id);
        Task<IEnumerable<Service>> GetAll();
        Task<bool> CheckNameExist(string name, int? id = null);
        Task<SelectList> GetSelectList();
    }
}
