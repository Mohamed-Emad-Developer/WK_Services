using Microsoft.AspNetCore.Identity;

namespace WK_Services.Domain.Models.User
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<ApplicationUserRole>? UserRoles { get; }
    }
}
