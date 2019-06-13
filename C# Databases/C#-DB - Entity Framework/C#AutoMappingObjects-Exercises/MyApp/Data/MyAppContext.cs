using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Data
{
    public class MyAppContext : DbContext
    {
        public MyAppContext()
        {
            
        }

        public MyAppContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Server=DESKTOP-M55K9NF\SQLEXPRESS;Database=MyApp;Integrated Security=True");
            }
        }
    }
}