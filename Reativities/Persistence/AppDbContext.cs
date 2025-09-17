using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        // DbSet for Activities
        public DbSet<Activity> Activities { get; set; }
    }
}
