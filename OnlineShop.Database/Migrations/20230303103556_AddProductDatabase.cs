using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Database.Migrations
{
    public partial class AddProductDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "CreationDateTime", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("570f9908-d532-4758-84a8-f3dd65b4b216"), 15000000m, new DateTime(2023, 3, 3, 13, 35, 54, 969, DateTimeKind.Local).AddTicks(400), "good", "/images/image1.jpg", "Ferrari" },
                    { new Guid("8ccdae17-15fe-4dab-b1ee-cd9753040886"), 25000000m, new DateTime(2023, 3, 3, 13, 35, 54, 970, DateTimeKind.Local).AddTicks(5260), "best", "/images/image2.jpg", "Lambo" },
                    { new Guid("365e1fe8-4cfd-4793-9fd5-93d03b50fc8c"), 5000000m, new DateTime(2023, 3, 3, 13, 35, 54, 970, DateTimeKind.Local).AddTicks(5334), "good", "/images/image3.jpg", "Camaro" },
                    { new Guid("2c2d5ed6-44ce-408d-ac6a-2901e6286529"), 7000000m, new DateTime(2023, 3, 3, 13, 35, 54, 970, DateTimeKind.Local).AddTicks(5339), "good", "/images/image4.jpg", "Mustang" },
                    { new Guid("d3f9cfb8-17e0-4433-8805-9f8cec2ac93a"), 7000m, new DateTime(2023, 3, 3, 13, 35, 54, 970, DateTimeKind.Local).AddTicks(5342), "not bad", "/images/image5.jpg", "Volga" },
                    { new Guid("0c7284c5-8ce8-4115-a643-a71b8cfa05e6"), 700m, new DateTime(2023, 3, 3, 13, 35, 54, 970, DateTimeKind.Local).AddTicks(5346), "foo", "/images/image6.jpg", "Kopeyka" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0c7284c5-8ce8-4115-a643-a71b8cfa05e6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2c2d5ed6-44ce-408d-ac6a-2901e6286529"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("365e1fe8-4cfd-4793-9fd5-93d03b50fc8c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("570f9908-d532-4758-84a8-f3dd65b4b216"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8ccdae17-15fe-4dab-b1ee-cd9753040886"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d3f9cfb8-17e0-4433-8805-9f8cec2ac93a"));
        }
    }
}
