using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingProductEntity(modelBuilder);

            OnModelCreatingCustomerEntity(modelBuilder);

            OnModelCreatingStoreEntity(modelBuilder);

            OnModelCreatingSaleEntity(modelBuilder);
        }

        private void OnModelCreatingSaleEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Sale>()
                .HasKey(p => p.SaleId);

            modelBuilder
                .Entity<Sale>()
                .Property(p => p.Date)
                .HasDefaultValueSql("GETDATE()");
        }

        private void OnModelCreatingStoreEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Store>()
                .HasKey(p => p.StoreId);

            modelBuilder
                .Entity<Store>()
                .Property(p => p.Name)
                .HasMaxLength(80)
                .IsUnicode();

            modelBuilder
                .Entity<Store>()
                .HasMany(p => p.Sales)
                .WithOne(p => p.Store);
        }

        private void OnModelCreatingCustomerEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Customer>()
                .HasKey(p => p.CustomerId);

            modelBuilder
                .Entity<Customer>()
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsUnicode();

            modelBuilder
                .Entity<Customer>()
                .Property(p => p.Email)
                .HasMaxLength(80)
                .IsUnicode();

            modelBuilder
                .Entity<Customer>()
                .HasMany(p => p.Sales)
                .WithOne(p => p.Customer);
        }

        private void OnModelCreatingProductEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .HasKey(p => p.ProductId);

            modelBuilder
                .Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode();

            modelBuilder
                .Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(250)
                .HasDefaultValue("No description");

            modelBuilder
                .Entity<Product>()
                .HasMany(p => p.Sales)
                .WithOne(p => p.Product);
        }
    }
}