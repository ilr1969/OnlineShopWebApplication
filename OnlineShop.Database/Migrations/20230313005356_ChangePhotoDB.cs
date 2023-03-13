using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Database.Migrations
{
    public partial class ChangePhotoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("36211d90-17e0-42d0-9f3b-3b17d2885ec1"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 13, 3, 53, 55, 252, DateTimeKind.Local).AddTicks(4661));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("59d7a46d-79a2-4a09-b6ad-a2333c3d3dcc"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 13, 3, 53, 55, 252, DateTimeKind.Local).AddTicks(4650));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8a5cf474-c473-48e1-bc3e-bbe0f22a80f2"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 13, 3, 53, 55, 251, DateTimeKind.Local).AddTicks(1107));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("968bfe01-31ba-44c0-a7c8-d1d04c1ffeb5"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 13, 3, 53, 55, 252, DateTimeKind.Local).AddTicks(4673));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b41fefb9-1c66-4f2a-86af-090ada282060"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 13, 3, 53, 55, 252, DateTimeKind.Local).AddTicks(4657));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e6d46e32-765c-487d-bf57-78759b32a47c"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 13, 3, 53, 55, 252, DateTimeKind.Local).AddTicks(4606));

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProductId",
                table: "Image",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("36211d90-17e0-42d0-9f3b-3b17d2885ec1"),
                column: "CreationDateTime",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("59d7a46d-79a2-4a09-b6ad-a2333c3d3dcc"),
                column: "CreationDateTime",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8a5cf474-c473-48e1-bc3e-bbe0f22a80f2"),
                column: "CreationDateTime",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("968bfe01-31ba-44c0-a7c8-d1d04c1ffeb5"),
                column: "CreationDateTime",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b41fefb9-1c66-4f2a-86af-090ada282060"),
                column: "CreationDateTime",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e6d46e32-765c-487d-bf57-78759b32a47c"),
                column: "CreationDateTime",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
