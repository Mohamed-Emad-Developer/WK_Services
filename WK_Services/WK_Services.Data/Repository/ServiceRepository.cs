using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WK_Services.Data.Context;
using WK_Services.Domain.IRepository;
using WK_Services.Domain.Models;

namespace WK_Services.Data.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        readonly ApplicationDbContext _write;
        readonly ReadDBContext _read;

        public ServiceRepository(ReadDBContext read, ApplicationDbContext write)
        {
            _read = read;
            _write = write;
        }

        public async Task<bool> Create(Service service)
        {
            try
            {
                await _write.Services.AddAsync(service);
                await _write.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }
        public async Task<bool> Update(Service service)
        {
            try
            {
                _write.Services.Update(service);
                await _write.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public async Task<Service?> Get(int id)
        {
            return await _read.Services.Where(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Service>> GetAll()
        {
            return await _read.Services.ToListAsync();
        }
        public IQueryable<Service> GetAllQueryable(Expression<Func<Service, bool>>? expression = null)
        {
            IQueryable<Service> query = _read.Services;
            if (expression != null)
                query = query.Where(expression);

            return query;
        }
    }
}
