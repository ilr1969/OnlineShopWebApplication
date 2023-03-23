﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShop.Database;

#nullable disable

namespace OnlineShop.Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlineShop.Database.Models.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("OnlineShop.Database.Models.CartItems", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("OnlineShop.Database.Models.CompareProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("CompareProducts");
                });

            modelBuilder.Entity("OnlineShop.Database.Models.FavoriteProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("FavoriteProducts");
                });

            modelBuilder.Entity("OnlineShop.Database.Models.Mark", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Marks");

                    b.HasData(
                        new
                        {
                            Id = new Guid("45e03085-c24d-4a9a-95a6-00d49dbf4bb9"),
                            Name = "Ferrari"
                        },
                        new
                        {
                            Id = new Guid("c589375f-897f-45f7-86a2-09011a939695"),
                            Name = "Lamborghini"
                        });
                });

            modelBuilder.Entity("OnlineShop.Database.Models.Model", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MarkId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MarkId");

                    b.ToTable("Models");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1e1620e7-abf1-4228-bfc1-d68d44c9fd83"),
                            MarkId = new Guid("45e03085-c24d-4a9a-95a6-00d49dbf4bb9"),
                            Name = "F560"
                        },
                        new
                        {
                            Id = new Guid("e617a298-74b2-42ff-a01d-72a8c1b38f79"),
                            MarkId = new Guid("c589375f-897f-45f7-86a2-09011a939695"),
                            Name = "Diablo"
                        });
                });

            modelBuilder.Entity("OnlineShop.Database.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("ConcurrencyToken")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<DateTime>("CreationDatetime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeliveryInfoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryInfoId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OnlineShop.Database.Models.OrderDeliveryInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Agree")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrderDeliveryInfo");
                });

            modelBuilder.Entity("OnlineShop.Database.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("ConcurrencyToken")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("MarkId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MarkId");

                    b.HasIndex("ModelId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8a5cf474-c473-48e1-bc3e-bbe0f22a80f2"),
                            Cost = 35000000m,
                            CreationDateTime = new DateTime(2023, 3, 23, 9, 14, 52, 447, DateTimeKind.Local).AddTicks(39),
                            Description = "super",
                            IsDeleted = false,
                            Name = "Ferrari"
                        },
                        new
                        {
                            Id = new Guid("e6d46e32-765c-487d-bf57-78759b32a47c"),
                            Cost = 25000000m,
                            CreationDateTime = new DateTime(2023, 3, 23, 9, 14, 52, 447, DateTimeKind.Local).AddTicks(67),
                            Description = "best",
                            IsDeleted = false,
                            Name = "Lambo"
                        },
                        new
                        {
                            Id = new Guid("59d7a46d-79a2-4a09-b6ad-a2333c3d3dcc"),
                            Cost = 5000000m,
                            CreationDateTime = new DateTime(2023, 3, 23, 9, 14, 52, 447, DateTimeKind.Local).AddTicks(71),
                            Description = "good",
                            IsDeleted = false,
                            Name = "Camaro"
                        },
                        new
                        {
                            Id = new Guid("b41fefb9-1c66-4f2a-86af-090ada282060"),
                            Cost = 7000000m,
                            CreationDateTime = new DateTime(2023, 3, 23, 9, 14, 52, 447, DateTimeKind.Local).AddTicks(75),
                            Description = "good",
                            IsDeleted = false,
                            Name = "Mustang"
                        },
                        new
                        {
                            Id = new Guid("36211d90-17e0-42d0-9f3b-3b17d2885ec1"),
                            Cost = 7000m,
                            CreationDateTime = new DateTime(2023, 3, 23, 9, 14, 52, 447, DateTimeKind.Local).AddTicks(79),
                            Description = "not bad",
                            IsDeleted = false,
                            Name = "Volga"
                        },
                        new
                        {
                            Id = new Guid("968bfe01-31ba-44c0-a7c8-d1d04c1ffeb5"),
                            Cost = 700m,
                            CreationDateTime = new DateTime(2023, 3, 23, 9, 14, 52, 447, DateTimeKind.Local).AddTicks(87),
                            Description = "foo",
                            IsDeleted = false,
                            Name = "Kopeyka"
                        });
                });

            modelBuilder.Entity("OnlineShop.Database.Models.ProductImages", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("ConcurrencyToken")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");

                    b.HasData(
                        new
                        {
                            Id = new Guid("73848a92-c52f-4972-9f8a-1dcc8c36acb8"),
                            Name = "/images/products/59d7a46d-79a2-4a09-b6ad-a2333c3d3dcc/1952d648-dca3-4072-b889-c2f3f5c6a9e0.jpg",
                            ProductId = new Guid("59d7a46d-79a2-4a09-b6ad-a2333c3d3dcc")
                        },
                        new
                        {
                            Id = new Guid("7e406def-9e54-48e2-9113-be1daacaeeb7"),
                            Name = "/images/products/36211d90-17e0-42d0-9f3b-3b17d2885ec1/26807f5d-b732-48d8-9a38-7ce09ffd3709.jpg",
                            ProductId = new Guid("36211d90-17e0-42d0-9f3b-3b17d2885ec1")
                        },
                        new
                        {
                            Id = new Guid("3f097c9f-fcb8-4d35-beee-4abf721d74ec"),
                            Name = "/images/products/8a5cf474-c473-48e1-bc3e-bbe0f22a80f2/daa919d9-7a5a-4370-bc3b-39dfb16ea8bc.jpg",
                            ProductId = new Guid("8a5cf474-c473-48e1-bc3e-bbe0f22a80f2")
                        },
                        new
                        {
                            Id = new Guid("c7aaafa9-8512-4f92-a1d3-d9a73db74c6a"),
                            Name = "/images/products/968bfe01-31ba-44c0-a7c8-d1d04c1ffeb5/31a97fb3-4c6e-4e98-968f-6c488f261670.jpg",
                            ProductId = new Guid("968bfe01-31ba-44c0-a7c8-d1d04c1ffeb5")
                        },
                        new
                        {
                            Id = new Guid("38b7ca0d-5381-4246-9f04-1eaf2ecb30e5"),
                            Name = "/images/products/b41fefb9-1c66-4f2a-86af-090ada282060/ee0e7ded-ba17-45c2-a932-d3bd2363de4d.jpg",
                            ProductId = new Guid("b41fefb9-1c66-4f2a-86af-090ada282060")
                        },
                        new
                        {
                            Id = new Guid("d93c51ef-44df-4e58-b6df-6adadbab2f89"),
                            Name = "/images/products/e6d46e32-765c-487d-bf57-78759b32a47c/36117249-2d5f-4fef-900e-9580fa641af5.jpg",
                            ProductId = new Guid("e6d46e32-765c-487d-bf57-78759b32a47c")
                        });
                });

            modelBuilder.Entity("OnlineShop.Database.Models.CartItems", b =>
                {
                    b.HasOne("OnlineShop.Database.Models.Cart", null)
                        .WithMany("CartItems")
                        .HasForeignKey("CartId");

                    b.HasOne("OnlineShop.Database.Models.Order", null)
                        .WithMany("CartItems")
                        .HasForeignKey("OrderId");

                    b.HasOne("OnlineShop.Database.Models.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Database.Models.CompareProduct", b =>
                {
                    b.HasOne("OnlineShop.Database.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Database.Models.FavoriteProduct", b =>
                {
                    b.HasOne("OnlineShop.Database.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Database.Models.Model", b =>
                {
                    b.HasOne("OnlineShop.Database.Models.Mark", "Mark")
                        .WithMany("Model")
                        .HasForeignKey("MarkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mark");
                });

            modelBuilder.Entity("OnlineShop.Database.Models.Order", b =>
                {
                    b.HasOne("OnlineShop.Database.Models.OrderDeliveryInfo", "DeliveryInfo")
                        .WithMany()
                        .HasForeignKey("DeliveryInfoId");

                    b.Navigation("DeliveryInfo");
                });

            modelBuilder.Entity("OnlineShop.Database.Models.Product", b =>
                {
                    b.HasOne("OnlineShop.Database.Models.Mark", "Mark")
                        .WithMany("Products")
                        .HasForeignKey("MarkId");

                    b.HasOne("OnlineShop.Database.Models.Model", "Model")
                        .WithMany("Products")
                        .HasForeignKey("ModelId");

                    b.Navigation("Mark");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("OnlineShop.Database.Models.ProductImages", b =>
                {
                    b.HasOne("OnlineShop.Database.Models.Product", null)
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineShop.Database.Models.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("OnlineShop.Database.Models.Mark", b =>
                {
                    b.Navigation("Model");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("OnlineShop.Database.Models.Model", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("OnlineShop.Database.Models.Order", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("OnlineShop.Database.Models.Product", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("ProductImages");
                });
#pragma warning restore 612, 618
        }
    }
}
