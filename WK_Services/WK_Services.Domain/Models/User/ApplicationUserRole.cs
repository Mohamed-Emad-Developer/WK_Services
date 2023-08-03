using Microsoft.AspNetCore.Identity;

namespace WK_Services.Domain.Models.User;

public class ApplicationUserRole : IdentityUserRole<string>
{
    public string UserId { get; set; }
    public string RoleId { get; set; }
    public ApplicationUser? User { get; set; }
    public ApplicationRole? Role { get; set; }
}
