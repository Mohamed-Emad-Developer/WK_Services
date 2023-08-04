using System.Linq.Expressions;
using WK_Services.Domain.Models;

namespace WK_Services.Domain.IRepository
{
    public interface IClientRepository
    {
        Task<bool> Create(Client client);
        Task<bool> Update(Client client);
        Task<Client?> Get(int id);
        Task<IEnumerable<Client>> GetAll();
        IQueryable<Client> GetAllQueryable(Expression<Func<Client, bool>>? expression = null);

    }
}