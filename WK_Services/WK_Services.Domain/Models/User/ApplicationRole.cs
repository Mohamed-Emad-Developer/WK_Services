using Microsoft.AspNetCore.Identity;

namespace WK_Services.Domain.Models.User;

public class ApplicationRole : IdentityRole<string>
{
    public ICollection<ApplicationUserRole>? UserRoles { get; }

}
