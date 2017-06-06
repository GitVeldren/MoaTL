using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace MoaTL.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Item> Items { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}