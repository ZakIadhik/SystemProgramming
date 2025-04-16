using Microsoft.EntityFrameworkCore;

namespace EfThreadingDemo
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=EfStudentsDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}