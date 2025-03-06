using Microsoft.EntityFrameworkCore;
using Day1_Task.Models;

namespace Day1_Task.Data
{
    public class EFCoreDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=ISHIKA\\SQLEXPRESS;Database=Student_Details_onConfig;Trusted_Connection=True;TrustServerCertificate= True");
            }
        }
    }
}
