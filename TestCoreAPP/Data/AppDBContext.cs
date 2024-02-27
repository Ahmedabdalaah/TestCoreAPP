using Microsoft.EntityFrameworkCore;
using TestCoreAPP.Areas.Employee.Models;
using TestCoreAPP.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TestCoreAPP.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {
        }
     public DbSet<Item> items { get; set; }
        public DbSet<Categories> categories { get; set; }
        public DbSet<Employee> employees { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>().HasData(
             new Categories { Id = 1, Name = "Select Catgory" },
             new Categories { Id = 2, Name = "Computers" },
             new Categories { Id = 3, Name = "Mobiles" },
             new Categories { Id = 4, Name = "Electrical" }
                );
            base.OnModelCreating(modelBuilder);
        }

    }
}
