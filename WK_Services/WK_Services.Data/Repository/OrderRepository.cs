using System.Linq.Expressions;
using WK_Services.Data.Context;
using WK_Services.Domain.IRepository;
using WK_Services.Domain.Models;

namespace WK_Services.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        readonly ApplicationDbContext _write;
        readonly ReadDBContext _read;

        public OrderRepository(ReadDBContext read, ApplicationDbContext write)
        {
            _read = read;
            _write = write;
        }

        public async Task<bool> Create(Order order)
        {
            try
            {
                await _write.Orders.AddAsync(order);
                await _write.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public IQueryable<Order> GetAll(Expression<Func<Order, bool>> expression)
        {
            return _read.Orders.Where(expression);
        }
    }
}
