using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDeliveryInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Agree = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDeliveryInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreationDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_OrderDeliveryInfo_DeliveryInfoId",
                        column: x => x.DeliveryInfoId,
                        principalTable: "OrderDeliveryInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompareProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompareProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompareProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FavoriteProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "CreationDateTime", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("36211d90-17e0-42d0-9f3b-3b17d2885ec1"), 7000m, new DateTime(2023, 3, 19, 10, 48, 9, 126, DateTimeKind.Local).AddTicks(545), "not bad", "Volga" },
                    { new Guid("59d7a46d-79a2-4a09-b6ad-a2333c3d3dcc"), 5000000m, new DateTime(2023, 3, 19, 10, 48, 9, 126, DateTimeKind.Local).AddTicks(484), "good", "Camaro" },
                    { new Guid("8a5cf474-c473-48e1-bc3e-bbe0f22a80f2"), 35000000m, new DateTime(2023, 3, 19, 10, 48, 9, 126, DateTimeKind.Local).AddTicks(453), "super", "Ferrari" },
                    { new Guid("968bfe01-31ba-44c0-a7c8-d1d04c1ffeb5"), 700m, new DateTime(2023, 3, 19, 10, 48, 9, 126, DateTimeKind.Local).AddTicks(556), "foo", "Kopeyka" },
                    { new Guid("b41fefb9-1c66-4f2a-86af-090ada282060"), 7000000m, new DateTime(2023, 3, 19, 10, 48, 9, 126, DateTimeKind.Local).AddTicks(487), "good", "Mustang" },
                    { new Guid("e6d46e32-765c-487d-bf57-78759b32a47c"), 25000000m, new DateTime(2023, 3, 19, 10, 48, 9, 126, DateTimeKind.Local).AddTicks(480), "best", "Lambo" }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Name", "ProductId" },
                values: new object[,]
                {
                    { new Guid("38b7ca0d-5381-4246-9f04-1eaf2ecb30e5"), "/images/products/b41fefb9-1c66-4f2a-86af-090ada282060/ee0e7ded-ba17-45c2-a932-d3bd2363de4d.jpg", new Guid("b41fefb9-1c66-4f2a-86af-090ada282060") },
                    { new Guid("3f097c9f-fcb8-4d35-beee-4abf721d74ec"), "/images/products/8a5cf474-c473-48e1-bc3e-bbe0f22a80f2/daa919d9-7a5a-4370-bc3b-39dfb16ea8bc.jpg", new Guid("8a5cf474-c473-48e1-bc3e-bbe0f22a80f2") },
                    { new Guid("73848a92-c52f-4972-9f8a-1dcc8c36acb8"), "/images/products/59d7a46d-79a2-4a09-b6ad-a2333c3d3dcc/1952d648-dca3-4072-b889-c2f3f5c6a9e0.jpg", new Guid("59d7a46d-79a2-4a09-b6ad-a2333c3d3dcc") },
                    { new Guid("7e406def-9e54-48e2-9113-be1daacaeeb7"), "/images/products/36211d90-17e0-42d0-9f3b-3b17d2885ec1/26807f5d-b732-48d8-9a38-7ce09ffd3709.jpg", new Guid("36211d90-17e0-42d0-9f3b-3b17d2885ec1") },
                    { new Guid("c7aaafa9-8512-4f92-a1d3-d9a73db74c6a"), "/images/products/968bfe01-31ba-44c0-a7c8-d1d04c1ffeb5/31a97fb3-4c6e-4e98-968f-6c488f261670.jpg", new Guid("968bfe01-31ba-44c0-a7c8-d1d04c1ffeb5") },
                    { new Guid("d93c51ef-44df-4e58-b6df-6adadbab2f89"), "/images/products/e6d46e32-765c-487d-bf57-78759b32a47c/36117249-2d5f-4fef-900e-9580fa641af5.jpg", new Guid("e6d46e32-765c-487d-bf57-78759b32a47c") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_OrderId",
                table: "CartItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CompareProducts_ProductId",
                table: "CompareProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteProducts_ProductId",
                table: "FavoriteProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryInfoId",
                table: "Orders",
                column: "DeliveryInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "CompareProducts");

            migrationBuilder.DropTable(
                name: "FavoriteProducts");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "OrderDeliveryInfo");
        }
    }
}
