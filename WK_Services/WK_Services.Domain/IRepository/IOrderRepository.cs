using System.Linq.Expressions;
using WK_Services.Domain.Models;

namespace WK_Services.Domain.IRepository
{
    public interface IOrderRepository
    {
        Task<bool> Create(Order order);
       IQueryable<Order> GetAll(Expression<Func<Order, bool>> expression);
    }
}
