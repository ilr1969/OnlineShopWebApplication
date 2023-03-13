using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Database.Migrations
{
    public partial class AddInitPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Products_ProductId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_ProductId",
                table: "Image");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "Image",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId1",
                table: "Image",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "Name", "ProductId", "ProductId1" },
                values: new object[,]
                {
                    { new Guid("99fb36b0-c926-41c7-8f78-b5bddf11a842"), "/images/image1.jpg", "8a5cf474-c473-48e1-bc3e-bbe0f22a80f2", null },
                    { new Guid("324152d7-65b5-4483-ab9a-c61eab4cd7a9"), "/images/image2.jpg", "e6d46e32-765c-487d-bf57-78759b32a47c", null },
                    { new Guid("153f4067-794e-4e33-906a-12eb4e61e51e"), "/images/image3.jpg", "59d7a46d-79a2-4a09-b6ad-a2333c3d3dcc", null },
                    { new Guid("836cc5ff-756a-4db2-8995-e79e814c9d01"), "/images/image4.jpg", "b41fefb9-1c66-4f2a-86af-090ada282060", null },
                    { new Guid("d942d587-9216-4ffb-97f3-54c30fa97a1f"), "/images/image5.jpg", "36211d90-17e0-42d0-9f3b-3b17d2885ec1", null },
                    { new Guid("699286c0-dfc6-44bd-b31b-d271362b652d"), "/images/image6.jpg", "968bfe01-31ba-44c0-a7c8-d1d04c1ffeb5", null }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("36211d90-17e0-42d0-9f3b-3b17d2885ec1"),
                columns: new[] { "CreationDateTime", "ImagePath" },
                values: new object[] { new DateTime(2023, 3, 13, 4, 48, 22, 179, DateTimeKind.Local).AddTicks(8220), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("59d7a46d-79a2-4a09-b6ad-a2333c3d3dcc"),
                columns: new[] { "CreationDateTime", "ImagePath" },
                values: new object[] { new DateTime(2023, 3, 13, 4, 48, 22, 179, DateTimeKind.Local).AddTicks(8208), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8a5cf474-c473-48e1-bc3e-bbe0f22a80f2"),
                columns: new[] { "CreationDateTime", "ImagePath" },
                values: new object[] { new DateTime(2023, 3, 13, 4, 48, 22, 178, DateTimeKind.Local).AddTicks(5815), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("968bfe01-31ba-44c0-a7c8-d1d04c1ffeb5"),
                columns: new[] { "CreationDateTime", "ImagePath" },
                values: new object[] { new DateTime(2023, 3, 13, 4, 48, 22, 179, DateTimeKind.Local).AddTicks(8229), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b41fefb9-1c66-4f2a-86af-090ada282060"),
                columns: new[] { "CreationDateTime", "ImagePath" },
                values: new object[] { new DateTime(2023, 3, 13, 4, 48, 22, 179, DateTimeKind.Local).AddTicks(8216), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e6d46e32-765c-487d-bf57-78759b32a47c"),
                columns: new[] { "CreationDateTime", "ImagePath" },
                values: new object[] { new DateTime(2023, 3, 13, 4, 48, 22, 179, DateTimeKind.Local).AddTicks(8162), null });

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProductId1",
                table: "Image",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Products_ProductId1",
                table: "Image",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Products_ProductId1",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_ProductId1",
                table: "Image");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("153f4067-794e-4e33-906a-12eb4e61e51e"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("324152d7-65b5-4483-ab9a-c61eab4cd7a9"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("699286c0-dfc6-44bd-b31b-d271362b652d"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("836cc5ff-756a-4db2-8995-e79e814c9d01"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("99fb36b0-c926-41c7-8f78-b5bddf11a842"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("d942d587-9216-4ffb-97f3-54c30fa97a1f"));

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "Image");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "Image",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("36211d90-17e0-42d0-9f3b-3b17d2885ec1"),
                columns: new[] { "CreationDateTime", "ImagePath" },
                values: new object[] { new DateTime(2023, 3, 13, 3, 53, 55, 252, DateTimeKind.Local).AddTicks(4661), "/images/image5.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("59d7a46d-79a2-4a09-b6ad-a2333c3d3dcc"),
                columns: new[] { "CreationDateTime", "ImagePath" },
                values: new object[] { new DateTime(2023, 3, 13, 3, 53, 55, 252, DateTimeKind.Local).AddTicks(4650), "/images/image3.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8a5cf474-c473-48e1-bc3e-bbe0f22a80f2"),
                columns: new[] { "CreationDateTime", "ImagePath" },
                values: new object[] { new DateTime(2023, 3, 13, 3, 53, 55, 251, DateTimeKind.Local).AddTicks(1107), "/images/image1.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("968bfe01-31ba-44c0-a7c8-d1d04c1ffeb5"),
                columns: new[] { "CreationDateTime", "ImagePath" },
                values: new object[] { new DateTime(2023, 3, 13, 3, 53, 55, 252, DateTimeKind.Local).AddTicks(4673), "/images/image6.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b41fefb9-1c66-4f2a-86af-090ada282060"),
                columns: new[] { "CreationDateTime", "ImagePath" },
                values: new object[] { new DateTime(2023, 3, 13, 3, 53, 55, 252, DateTimeKind.Local).AddTicks(4657), "/images/image4.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e6d46e32-765c-487d-bf57-78759b32a47c"),
                columns: new[] { "CreationDateTime", "ImagePath" },
                values: new object[] { new DateTime(2023, 3, 13, 3, 53, 55, 252, DateTimeKind.Local).AddTicks(4606), "/images/image2.jpg" });

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProductId",
                table: "Image",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Products_ProductId",
                table: "Image",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
