using System.Linq.Expressions;
using WK_Services.Domain.Models;

namespace WK_Services.Domain.IRepository
{
    public interface IServiceRepository
    {
        Task<bool> Create(Service service);
        Task<Service?> Get(int id);
        Task<IEnumerable<Service>> GetAll();
        IQueryable<Service> GetAllQueryable(Expression<Func<Service, bool>>? expression = null);
        Task<bool> Update(Service service);
    }
}