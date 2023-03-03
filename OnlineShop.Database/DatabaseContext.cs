using System;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Database.Models;

namespace OnlineShop.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate();
        }

        //Доступ к таблицам
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }
        public DbSet<CompareProduct> CompareProducts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        //Начальное заполнение товарами
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                            new Product() { Name = "Ferrari", Cost = 15000000, Description = "good", ImagePath = "/images/image1.jpg" },
                            new Product() { Name = "Lambo", Cost = 25000000, Description = "best", ImagePath = "/images/image2.jpg" },
                            new Product() { Name = "Camaro", Cost = 5000000, Description = "good", ImagePath = "/images/image3.jpg" },
                            new Product() { Name = "Mustang", Cost = 7000000, Description = "good", ImagePath = "/images/image4.jpg" },
                            new Product() { Name = "Volga", Cost = 7000, Description = "not bad", ImagePath = "/images/image5.jpg" },
                            new Product() { Name = "Kopeyka", Cost = 700, Description = "foo", ImagePath = "/images/image6.jpg" }
                );
        }
    }
}
