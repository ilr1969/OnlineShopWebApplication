using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace OnlineShop.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddMakrAndModel_AddColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MarkId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModelId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("36211d90-17e0-42d0-9f3b-3b17d2885ec1"),
                columns: new[] { "CreationDateTime", "MarkId", "ModelId" },
                values: new object[] { new DateTime(2023, 3, 20, 9, 19, 55, 127, DateTimeKind.Local).AddTicks(804), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("59d7a46d-79a2-4a09-b6ad-a2333c3d3dcc"),
                columns: new[] { "CreationDateTime", "MarkId", "ModelId" },
                values: new object[] { new DateTime(2023, 3, 20, 9, 19, 55, 127, DateTimeKind.Local).AddTicks(796), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8a5cf474-c473-48e1-bc3e-bbe0f22a80f2"),
                columns: new[] { "CreationDateTime", "MarkId", "ModelId" },
                values: new object[] { new DateTime(2023, 3, 20, 9, 19, 55, 127, DateTimeKind.Local).AddTicks(716), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("968bfe01-31ba-44c0-a7c8-d1d04c1ffeb5"),
                columns: new[] { "CreationDateTime", "MarkId", "ModelId" },
                values: new object[] { new DateTime(2023, 3, 20, 9, 19, 55, 127, DateTimeKind.Local).AddTicks(813), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b41fefb9-1c66-4f2a-86af-090ada282060"),
                columns: new[] { "CreationDateTime", "MarkId", "ModelId" },
                values: new object[] { new DateTime(2023, 3, 20, 9, 19, 55, 127, DateTimeKind.Local).AddTicks(800), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e6d46e32-765c-487d-bf57-78759b32a47c"),
                columns: new[] { "CreationDateTime", "MarkId", "ModelId" },
                values: new object[] { new DateTime(2023, 3, 20, 9, 19, 55, 127, DateTimeKind.Local).AddTicks(791), null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Products_MarkId",
                table: "Products",
                column: "MarkId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ModelId",
                table: "Products",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Marks_MarkId",
                table: "Products",
                column: "MarkId",
                principalTable: "Marks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Models_ModelId",
                table: "Products",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Marks_MarkId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Models_ModelId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MarkId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ModelId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Mark",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("36211d90-17e0-42d0-9f3b-3b17d2885ec1"),
                columns: new[] { "CreationDateTime", "Mark", "Model" },
                values: new object[] { new DateTime(2023, 3, 20, 9, 18, 51, 338, DateTimeKind.Local).AddTicks(286), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("59d7a46d-79a2-4a09-b6ad-a2333c3d3dcc"),
                columns: new[] { "CreationDateTime", "Mark", "Model" },
                values: new object[] { new DateTime(2023, 3, 20, 9, 18, 51, 338, DateTimeKind.Local).AddTicks(229), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8a5cf474-c473-48e1-bc3e-bbe0f22a80f2"),
                columns: new[] { "CreationDateTime", "Mark", "Model" },
                values: new object[] { new DateTime(2023, 3, 20, 9, 18, 51, 338, DateTimeKind.Local).AddTicks(201), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("968bfe01-31ba-44c0-a7c8-d1d04c1ffeb5"),
                columns: new[] { "CreationDateTime", "Mark", "Model" },
                values: new object[] { new DateTime(2023, 3, 20, 9, 18, 51, 338, DateTimeKind.Local).AddTicks(296), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b41fefb9-1c66-4f2a-86af-090ada282060"),
                columns: new[] { "CreationDateTime", "Mark", "Model" },
                values: new object[] { new DateTime(2023, 3, 20, 9, 18, 51, 338, DateTimeKind.Local).AddTicks(233), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e6d46e32-765c-487d-bf57-78759b32a47c"),
                columns: new[] { "CreationDateTime", "Mark", "Model" },
                values: new object[] { new DateTime(2023, 3, 20, 9, 18, 51, 338, DateTimeKind.Local).AddTicks(225), null, null });
        }
    }
}
