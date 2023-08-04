using Microsoft.AspNetCore.Identity;

namespace WK_Services.Domain.Models.User;

public class ApplicationRole : IdentityRole<string>
{
    public virtual ICollection<ApplicationUserRole> UserRoles { get; } = new List<ApplicationUserRole>();

}
