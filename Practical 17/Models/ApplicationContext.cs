using Microsoft.EntityFrameworkCore;

namespace Practical_17.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) :base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<UserLogin> UserLogin { get; set; }
    }
}
