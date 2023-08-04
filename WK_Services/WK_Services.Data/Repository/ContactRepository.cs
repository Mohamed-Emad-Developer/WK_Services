using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WK_Services.Data.Context;
using WK_Services.Domain.IRepository;
using WK_Services.Domain.Models;

namespace WK_Contacts.Data.Repository
{
    public class ContactRepository : IContactRepository
    {
        readonly ApplicationDbContext _write;
        readonly ReadDBContext _read;

        public ContactRepository(ReadDBContext read, ApplicationDbContext write)
        {
            _read = read;
            _write = write;
        }

        public async Task<bool> Create(Contact contact)
        {
            try
            {
                await _write.Contacts.AddAsync(contact);
                await _write.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }
        public async Task<bool> Update(Contact contact)
        {
            try
            {
                _write.Contacts.Update(contact);
                await _write.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public async Task<Contact?> Get(int id)
        {
            return await _read.Contacts.Where(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _read.Contacts.ToListAsync();
        }
        public IQueryable<Contact> GetAllQueryable(Expression<Func<Contact, bool>>? expression = null)
        {
            IQueryable<Contact> query = _write.Contacts;
            if (expression != null)
                query = query.Where(expression);

            return query;
        }
    }
}
