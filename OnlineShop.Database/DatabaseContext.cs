using Microsoft.EntityFrameworkCore;
using OnlineShop.Database.Models;

namespace OnlineShop.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        //Доступ к таблицам
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        /*public DbSet<CartItem> CartItems { get; set; }*/
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }
        public DbSet<CompareProduct> CompareProducts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        /*public DbSet<OrderStatus> OrderStatuses { get; set; }*/
    }
}
