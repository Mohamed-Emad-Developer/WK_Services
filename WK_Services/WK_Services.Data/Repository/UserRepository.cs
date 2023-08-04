using Microsoft.AspNetCore.Identity;
using WK_Services.Domain.IRepository;
using WK_Services.Domain.Models.User;
 

namespace WK_Services.Data.Repository
{
    public class UserRepository: IUserRepository
    {
        readonly UserManager<ApplicationUser> _userManager;
        readonly RoleManager<ApplicationRole> _roleManager;

        public UserRepository(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<bool> AddUser(ApplicationUser user, string password, string roleName)
        {
            try
            {
                var roleExist = await _roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {

                    var role = new ApplicationRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = roleName,

                    };
                    var roleCreated = await _roleManager.CreateAsync(role);
                    if (roleCreated.Succeeded)
                    {

                        var userCreated = await _userManager.CreateAsync(user, password);
                        if (userCreated.Succeeded)
                        {
                            var assignToRole = await _userManager.AddToRoleAsync(user, roleName);
                            if (assignToRole.Succeeded)
                            {

                                return true;
                            }
                        }
                    }
                }
                else
                {

                    var userCreated = await _userManager.CreateAsync(user, password);
                    if (userCreated.Succeeded)
                    {
                        var assignToRole = await _userManager.AddToRoleAsync(user, roleName);
                        if (assignToRole.Succeeded)
                        {

                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

          
            }
            return false;
            
        }

        public async Task<bool> UserExist(string email)
        {
           return await _userManager.FindByEmailAsync(email) != null;
        }
        public async Task<ApplicationUser?> GetBy(string email)
        {
           return await _userManager.FindByEmailAsync(email) ;
        }
    }
}
