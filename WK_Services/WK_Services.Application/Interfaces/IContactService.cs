using WK_Services.Application.ViewModels;
using WK_Services.Application.ViewModels.FatatableViewModels;
using WK_Services.Application.ViewModels.User;
using WK_Services.Domain.Models;

namespace WK_Services.Application.Interfaces
{
    public interface IContactService
    {
        Task<ResultVM> Create(CreateContactVM ContactVM);
        Task<Contact?> Get(int id);
        Task<IEnumerable<Contact>> GetAll();
        Task<bool> Update(ContactVM ContactVM);
        Task<ContactVM?> GetContactVM(int id);
        Task<DataTableVM<ContactVM>> GetContactVMDataTableVM(int clientId, int? take = null, int? skip = null);
        Task<(int Id, string Name)> GetClientIdByContactUserId(string contactUserId);
    }
}
