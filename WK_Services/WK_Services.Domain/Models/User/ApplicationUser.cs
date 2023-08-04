using Microsoft.AspNetCore.Identity;

namespace WK_Services.Domain.Models.User
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; } = new List<ApplicationUserRole>();
    }
}
