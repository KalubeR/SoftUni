using SULS.Models;

namespace SULS.Data
{
    using Microsoft.EntityFrameworkCore;

    public class SULSContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Problem> Problems { get; set; }

        public DbSet<Submission> Submissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSettings.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Problem>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Submission>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Submission>()
                .HasOne(s => s.Problem);

            modelBuilder.Entity<Submission>()
                .HasOne(s => s.User);

            base.OnModelCreating(modelBuilder);
        }
    }
}