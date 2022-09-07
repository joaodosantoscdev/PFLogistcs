using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using PFLogistcs.Models;

namespace PFLogistcs.Context
{
    public class PFLogisticsDbContext : DbContext
    {
        public PFLogisticsDbContext(DbContextOptions<PFLogisticsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder) {
            
            builder.Entity<Client>()
                .HasMany<Address>(client => client.Address)
                .WithOne(address => address.Client)
                .HasForeignKey(address => address.AddressId);

            builder.Entity<Product>()
                .HasOne(product => product.Category)
                .WithMany(category => category.Products)
                .HasForeignKey(product => product.CategoryId);

            builder.Entity<Order>()
                .HasOne(order => order.Client)
                .WithMany(client => client.Orders)
                .HasForeignKey(order => order.ClientId);
            
            builder.Entity<ItemOrder>()
                .HasKey(key => new { key.ProductId, key.OrderId } );

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ItemOrder> ItemOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}