using WK_Services.Domain.Models.User;

namespace WK_Services.Domain.IRepository
{
    public interface IUserRepository
    {
        Task<bool> AddUser(ApplicationUser user, string password, string roleName);
        Task<bool> UserExist(string email);
        Task<ApplicationUser?> GetBy(string email);
    }
}
