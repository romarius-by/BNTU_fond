using BNTU_fond.Models;
using Microsoft.EntityFrameworkCore;

namespace BNTU_fond.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Auditory> Auditories { get; set; }
    }
}
