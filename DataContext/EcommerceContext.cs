using EcommerceApplication2.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApplication2.DataContext
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(DbContextOptions<EcommerceContext> options)
        : base(options)
        {

        }

        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

    }
}