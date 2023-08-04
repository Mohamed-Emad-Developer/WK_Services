using System.Linq.Expressions;
using WK_Services.Domain.Models;

namespace WK_Services.Domain.IRepository
{
    public interface IContactRepository
    {
        Task<bool> Create(Contact contact);
        Task<bool> Update(Contact contact);
        Task<Contact?> Get(int id);
        Task<IEnumerable<Contact>> GetAll();
        IQueryable<Contact> GetAllQueryable(Expression<Func<Contact, bool>>? expression = null);

    }
}