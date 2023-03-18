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

            /*
                        modelBuilder.Entity<Image>().HasData(new List<Image>()
                        {
                            new Image(new Guid("73848a92-c52f-4972-9f8a-1dcc8c36acb8"), "/images/products/59d7a46d-79a2-4a09-b6ad-a2333c3d3dcc/1952d648-dca3-4072-b889-c2f3f5c6a9e0.jpg"),
                            new Image(new Guid("7e406def-9e54-48e2-9113-be1daacaeeb7"), "/images/products/36211d90-17e0-42d0-9f3b-3b17d2885ec1/26807f5d-b732-48d8-9a38-7ce09ffd3709.jpg"),
                            new Image(new Guid("3f097c9f-fcb8-4d35-beee-4abf721d74ec"), "/images/products/8a5cf474-c473-48e1-bc3e-bbe0f22a80f2/daa919d9-7a5a-4370-bc3b-39dfb16ea8bc.jpg"),
                            new Image(new Guid("c7aaafa9-8512-4f92-a1d3-d9a73db74c6a"), "/images/products/968bfe01-31ba-44c0-a7c8-d1d04c1ffeb5/31a97fb3-4c6e-4e98-968f-6c488f261670.jpg"),
                            new Image(new Guid("38b7ca0d-5381-4246-9f04-1eaf2ecb30e5"), "/images/products/b41fefb9-1c66-4f2a-86af-090ada282060/ee0e7ded-ba17-45c2-a932-d3bd2363de4d.jpg"),
                            new Image(new Guid("d93c51ef-44df-4e58-b6df-6adadbab2f89"), "/images/products/e6d46e32-765c-487d-bf57-78759b32a47c/36117249-2d5f-4fef-900e-9580fa641af5.jpg"),
                        });*/

            modelBuilder.Entity<Product>().HasData(new List<Product>()
                        {
                            new Product(new Guid("8a5cf474-c473-48e1-bc3e-bbe0f22a80f2"), "Ferrari", 35000000, "super" ),
                            new Product(new Guid("e6d46e32-765c-487d-bf57-78759b32a47c"), "Lambo", 25000000, "best" ),
                            new Product(new Guid("59d7a46d-79a2-4a09-b6ad-a2333c3d3dcc"), "Camaro", 5000000, "good" ),
                            new Product(new Guid("b41fefb9-1c66-4f2a-86af-090ada282060"), "Mustang", 7000000, "good" ),
                            new Product(new Guid("36211d90-17e0-42d0-9f3b-3b17d2885ec1"), "Volga", 7000, "not bad" ),
                            new Product(new Guid("968bfe01-31ba-44c0-a7c8-d1d04c1ffeb5"), "Kopeyka", 700, "foo" ),
                        });

            /*
                        modelBuilder.Entity<Product>(p =>
                        {
                            p.HasData(new Product(new Guid("8a5cf474-c473-48e1-bc3e-bbe0f22a80f2"), "Ferrari", 35000000, "super"));
                            p.OwnsOne(i => i.Images).HasData(new Image(new Guid("3f097c9f-fcb8-4d35-beee-4abf721d74ec"), "/images/products/8a5cf474-c473-48e1-bc3e-bbe0f22a80f2/daa919d9-7a5a-4370-bc3b-39dfb16ea8bc.jpg"));
                        });
                        modelBuilder.Entity<Product>(p =>
                        {
                            p.HasData(new Product(new Guid("e6d46e32-765c-487d-bf57-78759b32a47c"), "Lambo", 25000000, "best"));
                            p.OwnsOne(i => i.Images).HasData(new Image(new Guid("d93c51ef-44df-4e58-b6df-6adadbab2f89"), "/images/products/e6d46e32-765c-487d-bf57-78759b32a47c/36117249-2d5f-4fef-900e-9580fa641af5.jpg"));
                        });
                        modelBuilder.Entity<Product>(p =>
                        {
                            p.HasData(new Product(new Guid("59d7a46d-79a2-4a09-b6ad-a2333c3d3dcc"), "Camaro", 5000000, "good"));
                            p.OwnsOne(i => i.Images).HasData(new Image(new Guid("73848a92-c52f-4972-9f8a-1dcc8c36acb8"), "/images/products/59d7a46d-79a2-4a09-b6ad-a2333c3d3dcc/1952d648-dca3-4072-b889-c2f3f5c6a9e0.jpg"));
                        });
                        modelBuilder.Entity<Product>(p =>
                        {
                            p.HasData(new Product(new Guid("b41fefb9-1c66-4f2a-86af-090ada282060"), "Mustang", 7000000, "good"));
                            p.OwnsOne(i => i.Images).HasData(new Image(new Guid("38b7ca0d-5381-4246-9f04-1eaf2ecb30e5"), "/images/products/b41fefb9-1c66-4f2a-86af-090ada282060/ee0e7ded-ba17-45c2-a932-d3bd2363de4d.jpg"));
                        });
                        modelBuilder.Entity<Product>(p =>
                        {
                            p.HasData(new Product(new Guid("36211d90-17e0-42d0-9f3b-3b17d2885ec1"), "Volga", 7000, "not bad"));
                            p.OwnsOne(i => i.Images).HasData(new Image(new Guid("7e406def-9e54-48e2-9113-be1daacaeeb7"), "/images/products/36211d90-17e0-42d0-9f3b-3b17d2885ec1/26807f5d-b732-48d8-9a38-7ce09ffd3709.jpg"));
                        });
                        modelBuilder.Entity<Product>(p =>
                        {
                            p.HasData(new Product(new Guid("968bfe01-31ba-44c0-a7c8-d1d04c1ffeb5"), "Kopeyka", 700, "foo"));
                            p.OwnsOne(i => i.Images).HasData(new Image(new Guid("c7aaafa9-8512-4f92-a1d3-d9a73db74c6a"), "/images/products/968bfe01-31ba-44c0-a7c8-d1d04c1ffeb5/31a97fb3-4c6e-4e98-968f-6c488f261670.jpg"));
                        });*/


        }
    }
}
