using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WK_Services.Application.Interfaces;
using WK_Services.Application.ViewModels;
using WK_Services.Application.ViewModels.FatatableViewModels;
using WK_Services.Application.ViewModels.User;
using WK_Services.Domain.Commands.ContactCommands;
using WK_Services.Domain.Core.Bus;
using WK_Services.Domain.IRepository;
using WK_Services.Domain.Models;
using WK_Services.Domain.Models.User;
using WK_Services.Utility;

namespace WK_Services.Application.Services
{
    public class ContactService : IContactService
    {
        readonly IMediatorHandler _bus;
        readonly IContactRepository _contactRepository;
        readonly IMapper _mapper;
        readonly IUserRepository _userRepository;

        public ContactService(IMediatorHandler bus, IContactRepository contactRepository, IMapper mapper, IUserRepository userRepository)
        {
            _bus = bus;
            _contactRepository = contactRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<ResultVM> Create(CreateContactVM ContactVM)
        {
            var result = new ResultVM();
            try
            {
                if (await _userRepository.UserExist(ContactVM.Email))
                {
                    result.IsSucceeded = false;
                    result.Error = "email is already exist";
                    return result;
                }
                var user = new ApplicationUser
                {
                    Name = ContactVM.Name,
                    Email = ContactVM.Email,
                    UserName = ContactVM.UserName,

                };
                var addUserResult = await _userRepository.AddUser(user, ContactVM.Password, Roles.Contact);

                if (addUserResult)
                {
                    var contact = _mapper.Map<Contact>(ContactVM);
                    contact.UserId = user.Id;
                    contact.CreatedDateOnUtc = DateTime.UtcNow;
                    contact.UpdatedDateOnUtc = DateTime.UtcNow;
                    var createContactCommand = new CreateContactCommand(contact);
                    result.IsSucceeded = await _bus.SendCommand(createContactCommand);
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.Error = "An error occurred";
            }

            return result;
        }

        public async Task<Contact?> Get(int id)
        {
            return await _contactRepository.Get(id);
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _contactRepository.GetAll();
        }

        public async Task<bool> Update(ContactVM ContactVM)
        {

            var contact = await _contactRepository.GetAllQueryable(c => c.Id == ContactVM.Id).Include(c => c.User).FirstOrDefaultAsync();
            if (contact == null)
                return false;
 
             
            contact.User.Name = ContactVM.Name;
            contact.User.UserName = ContactVM.UserName;
            contact.Mobile = ContactVM.Mobile;
            
            contact.UpdatedDateOnUtc = DateTime.UtcNow;
            var updateContactCommand = new UpdateContactCommand(contact);
            var result = await _bus.SendCommand(updateContactCommand);
            return result;
        }

        public async Task<ContactVM?> GetContactVM(int id)
        {
            return await _contactRepository.GetAllQueryable(c => c.Id == id).ProjectTo<ContactVM>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();

        }

        public async Task<DataTableVM<ContactVM>> GetContactVMDataTableVM(int clientId, int? take = null, int? skip = null)
        {
            var result = new DataTableVM<ContactVM>();
            var query = _contactRepository.GetAllQueryable(c => c.ClientId == clientId).ProjectTo<ContactVM>(_mapper.ConfigurationProvider);

            result.Data = await query.Skip(skip ?? 0).Take(take ?? 10).ToListAsync();
            result.RecordsFiltered = result.Data.Count();
            result.RecordsTotal = await query.Select(c => c.Id).CountAsync();
            return result;
        }

        public async Task<(int Id, string Name)> GetClientIdByContactUserId(string contactUserId)
        {
            var data = await _contactRepository.GetAllQueryable(c => c.UserId == contactUserId).Include(c => c.Client).Select(c => new { c.ClientId, c.Client.Name }).FirstOrDefaultAsync();
            return (data.ClientId, data.Name);
        }
    }
}
