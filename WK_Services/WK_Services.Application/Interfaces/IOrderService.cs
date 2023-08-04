using WK_Services.Application.ViewModels;
using WK_Services.Application.ViewModels.FatatableViewModels;

namespace WK_Services.Application.Interfaces
{
    public interface IOrderService
    {
        Task<OrderResult> Create(OrderVM orderVm, string contactUserId);
        Task<DataTableVM<OrderTableVM>> GetOrderVMDataTableVM(OrderFilter filter,int? clientId = null, int? take = null, int? skip = null);
    }
}
