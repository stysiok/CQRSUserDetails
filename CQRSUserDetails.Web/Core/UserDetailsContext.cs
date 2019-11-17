using Microsoft.EntityFrameworkCore;

namespace CQRSUserDetails.Web.Core
{
    public class UserDetailsContext : DbContext 
    {
        public DbSet<Models.UserDetails> UserDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseInMemoryDatabase("UserDetails");
            return;
        }
    }
}