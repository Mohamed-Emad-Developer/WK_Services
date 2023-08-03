using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WK_Services.Domain.Models.User;

namespace WK_Services.Data.Context
{
    public abstract partial class MainDbContext : IdentityDbContext<
       ApplicationUser, ApplicationRole, string,
       IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>,
       IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public MainDbContext()
        {

        }

        public MainDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

             
            base.OnModelCreating(builder);


            builder.Entity<ApplicationUser>(b =>
            {
               
                b.HasMany(e => e.UserRoles)
               .WithOne(e => e.User)
                 .HasForeignKey(uc => uc.UserId)
                 .IsRequired();

                
            });

            builder.Entity<ApplicationRole>(b =>
            {
              
                b.HasMany(e => e.UserRoles)
                .WithOne(e => e.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
            });
        }
      

    }

    public class ApplicationDbContext : MainDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public ApplicationDbContext()
        {

        }
    }

    public class ReadDBContext : MainDbContext
    {
        public ReadDBContext()
        {

        }
        public ReadDBContext(DbContextOptions<ReadDBContext> options) : base(options)
        {

        }
        [Obsolete("This context is read-only", true)]
        public new int SaveChanges()
        {
            throw new InvalidOperationException("This context is read-only.");
        }

        [Obsolete("This context is read-only", true)]
        public new int SaveChanges(bool acceptAll)
        {
            throw new InvalidOperationException("This context is read-only.");
        }

        [Obsolete("This context is read-only", true)]
        public new Task<int> SaveChangesAsync(CancellationToken token = default(CancellationToken))
        {
            throw new InvalidOperationException("This context is read-only.");
        }

        [Obsolete("This context is read-only", true)]
        public new Task<int> SaveChangesAsync(bool acceptAll, CancellationToken token = default(CancellationToken))
        {
            throw new InvalidOperationException("This context is read-only.");
        }
    }
}
