using Microsoft.EntityFrameworkCore;
using Day1_Task.Models;

namespace Day1_Task.Data
{
    public class EFCoreDbContext : DbContext
    {
        public EFCoreDbContext(DbContextOptions<EFCoreDbContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }

        
    }
}
