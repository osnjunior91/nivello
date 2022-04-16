using Microsoft.EntityFrameworkCore;
using Nivello.Infrastructure.Data.Model;
using System.Diagnostics.CodeAnalysis;

namespace Nivello.Infrastructure.Data.Context
{
    [ExcludeFromCodeCoverage]
    public class DataContext : DbContext
    {
        public DbSet<SystemAdmin> SystemAdmin { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<AuctionsBid> AuctionsBid { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SystemAdmin>()
                .HasData(new SystemAdmin("Admin", "admin@nivello.com", "123456"));

            base.OnModelCreating(modelBuilder);
        }

    }
}
