using System;
using System.Collections.Generic;
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
        public DbSet<Order> Orders { get; set; }

        //Начальное заполнение товарами
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
                            new Product(new Guid("8a5cf474-c473-48e1-bc3e-bbe0f22a80f2"), "Ferrari", 35000000, "super", "/images/image1.jpg") ,
                            new Product(new Guid("e6d46e32-765c-487d-bf57-78759b32a47c"), "Lambo", 25000000, "best", "/images/image2.jpg" ),
                            new Product(new Guid("59d7a46d-79a2-4a09-b6ad-a2333c3d3dcc"), "Camaro", 5000000, "good", "/images/image3.jpg" ),
                            new Product(new Guid("b41fefb9-1c66-4f2a-86af-090ada282060"), "Mustang", 7000000, "good", "/images/image4.jpg" ),
                            new Product(new Guid("36211d90-17e0-42d0-9f3b-3b17d2885ec1"), "Volga", 7000, "not bad", "/images/image5.jpg" ),
                            new Product(new Guid("968bfe01-31ba-44c0-a7c8-d1d04c1ffeb5"), "Kopeyka", 700, "foo", "/images/image6.jpg" ),
            });
        }
    }
}
