using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedFlagOnProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("36211d90-17e0-42d0-9f3b-3b17d2885ec1"),
                columns: new[] { "CreationDateTime", "IsDeleted" },
                values: new object[] { new DateTime(2023, 3, 20, 8, 33, 13, 809, DateTimeKind.Local).AddTicks(2896), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("59d7a46d-79a2-4a09-b6ad-a2333c3d3dcc"),
                columns: new[] { "CreationDateTime", "IsDeleted" },
                values: new object[] { new DateTime(2023, 3, 20, 8, 33, 13, 809, DateTimeKind.Local).AddTicks(2820), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8a5cf474-c473-48e1-bc3e-bbe0f22a80f2"),
                columns: new[] { "CreationDateTime", "IsDeleted" },
                values: new object[] { new DateTime(2023, 3, 20, 8, 33, 13, 809, DateTimeKind.Local).AddTicks(2792), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("968bfe01-31ba-44c0-a7c8-d1d04c1ffeb5"),
                columns: new[] { "CreationDateTime", "IsDeleted" },
                values: new object[] { new DateTime(2023, 3, 20, 8, 33, 13, 809, DateTimeKind.Local).AddTicks(2907), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b41fefb9-1c66-4f2a-86af-090ada282060"),
                columns: new[] { "CreationDateTime", "IsDeleted" },
                values: new object[] { new DateTime(2023, 3, 20, 8, 33, 13, 809, DateTimeKind.Local).AddTicks(2891), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e6d46e32-765c-487d-bf57-78759b32a47c"),
                columns: new[] { "CreationDateTime", "IsDeleted" },
                values: new object[] { new DateTime(2023, 3, 20, 8, 33, 13, 809, DateTimeKind.Local).AddTicks(2816), false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("36211d90-17e0-42d0-9f3b-3b17d2885ec1"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 19, 10, 48, 9, 126, DateTimeKind.Local).AddTicks(545));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("59d7a46d-79a2-4a09-b6ad-a2333c3d3dcc"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 19, 10, 48, 9, 126, DateTimeKind.Local).AddTicks(484));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8a5cf474-c473-48e1-bc3e-bbe0f22a80f2"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 19, 10, 48, 9, 126, DateTimeKind.Local).AddTicks(453));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("968bfe01-31ba-44c0-a7c8-d1d04c1ffeb5"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 19, 10, 48, 9, 126, DateTimeKind.Local).AddTicks(556));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b41fefb9-1c66-4f2a-86af-090ada282060"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 19, 10, 48, 9, 126, DateTimeKind.Local).AddTicks(487));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e6d46e32-765c-487d-bf57-78759b32a47c"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 19, 10, 48, 9, 126, DateTimeKind.Local).AddTicks(480));
        }
    }
}
