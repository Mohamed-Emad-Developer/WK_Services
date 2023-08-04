using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WK_Services.Data.Context;
using WK_Services.Domain.IRepository;
using WK_Services.Domain.Models;

namespace WK_Clients.Data.Repository
{
    public class ClientRepository : IClientRepository
    {
        readonly ApplicationDbContext _write;
        readonly ReadDBContext _read;

        public ClientRepository(ReadDBContext read, ApplicationDbContext write)
        {
            _read = read;
            _write = write;
        }

        public async Task<bool> Create(Client client)
        {
            try
            {
                await _write.Clients.AddAsync(client);
                await _write.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }
        public async Task<bool> Update(Client client)
        {
            try
            {
                _write.Clients.Update(client);
                await _write.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public async Task<Client?> Get(int id)
        {
            return await _read.Clients.Where(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _read.Clients.ToListAsync();
        }
        public IQueryable<Client> GetAllQueryable(Expression<Func<Client, bool>>? expression = null)
        {
            IQueryable<Client> query = _read.Clients;
            if (expression != null)
                query = query.Where(expression);

            return query;
        }
    }
}
