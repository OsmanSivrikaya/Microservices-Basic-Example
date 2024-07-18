using Microsoft.EntityFrameworkCore;
using Order.API.Models.Entities;

namespace Order.API.Models
{
    public class OrderAPIDbContext : DbContext
    {
        public OrderAPIDbContext(DbContextOptions<OrderAPIDbContext> options) : base(options)
        {
        }

        public DbSet<Entities.Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; } // Doğru şekilde 'OrderItems' olarak tanımlandığından emin olun

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Optional: Add any additional model configuration here
        }
    }
}
