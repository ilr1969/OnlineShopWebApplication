using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddBaseClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationDatetime",
                table: "Orders",
                newName: "CreationDateTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDateTime",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateTime",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDateTime",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDateTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateTime",
                table: "OrderDeliveryInfo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDateTime",
                table: "OrderDeliveryInfo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateTime",
                table: "Models",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDateTime",
                table: "Models",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateTime",
                table: "Marks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDateTime",
                table: "Marks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateTime",
                table: "FavoriteProducts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDateTime",
                table: "FavoriteProducts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateTime",
                table: "CompareProducts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDateTime",
                table: "CompareProducts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateTime",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDateTime",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateTime",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDateTime",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: new Guid("45e03085-c24d-4a9a-95a6-00d49dbf4bb9"),
                columns: new[] { "CreationDateTime", "EditDateTime" },
                values: new object[] { new DateTime(2023, 4, 3, 9, 47, 54, 655, DateTimeKind.Local).AddTicks(3800), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: new Guid("c589375f-897f-45f7-86a2-09011a939695"),
                columns: new[] { "CreationDateTime", "EditDateTime" },
                values: new object[] { new DateTime(2023, 4, 3, 9, 47, 54, 655, DateTimeKind.Local).AddTicks(3806), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("1e1620e7-abf1-4228-bfc1-d68d44c9fd83"),
                columns: new[] { "CreationDateTime", "EditDateTime" },
                values: new object[] { new DateTime(2023, 4, 3, 9, 47, 54, 655, DateTimeKind.Local).AddTicks(3839), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("e617a298-74b2-42ff-a01d-72a8c1b38f79"),
                columns: new[] { "CreationDateTime", "EditDateTime" },
                values: new object[] { new DateTime(2023, 4, 3, 9, 47, 54, 655, DateTimeKind.Local).AddTicks(3845), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("38b7ca0d-5381-4246-9f04-1eaf2ecb30e5"),
                columns: new[] { "CreationDateTime", "EditDateTime" },
                values: new object[] { new DateTime(2023, 4, 3, 9, 47, 54, 655, DateTimeKind.Local).AddTicks(3756), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("3f097c9f-fcb8-4d35-beee-4abf721d74ec"),
                columns: new[] { "CreationDateTime", "EditDateTime" },
                values: new object[] { new DateTime(2023, 4, 3, 9, 47, 54, 655, DateTimeKind.Local).AddTicks(3748), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("73848a92-c52f-4972-9f8a-1dcc8c36acb8"),
                columns: new[] { "CreationDateTime", "EditDateTime" },
                values: new object[] { new DateTime(2023, 4, 3, 9, 47, 54, 655, DateTimeKind.Local).AddTicks(3739), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("7e406def-9e54-48e2-9113-be1daacaeeb7"),
                columns: new[] { "CreationDateTime", "EditDateTime" },
                values: new object[] { new DateTime(2023, 4, 3, 9, 47, 54, 655, DateTimeKind.Local).AddTicks(3744), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("c7aaafa9-8512-4f92-a1d3-d9a73db74c6a"),
                columns: new[] { "CreationDateTime", "EditDateTime" },
                values: new object[] { new DateTime(2023, 4, 3, 9, 47, 54, 655, DateTimeKind.Local).AddTicks(3752), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("d93c51ef-44df-4e58-b6df-6adadbab2f89"),
                columns: new[] { "CreationDateTime", "EditDateTime" },
                values: new object[] { new DateTime(2023, 4, 3, 9, 47, 54, 655, DateTimeKind.Local).AddTicks(3761), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("36211d90-17e0-42d0-9f3b-3b17d2885ec1"),
                columns: new[] { "CreationDateTime", "EditDateTime" },
                values: new object[] { new DateTime(2023, 4, 3, 9, 47, 54, 655, DateTimeKind.Local).AddTicks(3665), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("59d7a46d-79a2-4a09-b6ad-a2333c3d3dcc"),
                columns: new[] { "CreationDateTime", "EditDateTime" },
                values: new object[] { new DateTime(2023, 4, 3, 9, 47, 54, 655, DateTimeKind.Local).AddTicks(3596), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8a5cf474-c473-48e1-bc3e-bbe0f22a80f2"),
                columns: new[] { "CreationDateTime", "EditDateTime" },
                values: new object[] { new DateTime(2023, 4, 3, 9, 47, 54, 655, DateTimeKind.Local).AddTicks(3569), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("968bfe01-31ba-44c0-a7c8-d1d04c1ffeb5"),
                columns: new[] { "CreationDateTime", "EditDateTime" },
                values: new object[] { new DateTime(2023, 4, 3, 9, 47, 54, 655, DateTimeKind.Local).AddTicks(3675), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b41fefb9-1c66-4f2a-86af-090ada282060"),
                columns: new[] { "CreationDateTime", "EditDateTime" },
                values: new object[] { new DateTime(2023, 4, 3, 9, 47, 54, 655, DateTimeKind.Local).AddTicks(3600), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e6d46e32-765c-487d-bf57-78759b32a47c"),
                columns: new[] { "CreationDateTime", "EditDateTime" },
                values: new object[] { new DateTime(2023, 4, 3, 9, 47, 54, 655, DateTimeKind.Local).AddTicks(3592), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EditDateTime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "EditDateTime",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "EditDateTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "OrderDeliveryInfo");

            migrationBuilder.DropColumn(
                name: "EditDateTime",
                table: "OrderDeliveryInfo");

            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "EditDateTime",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "EditDateTime",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "FavoriteProducts");

            migrationBuilder.DropColumn(
                name: "EditDateTime",
                table: "FavoriteProducts");

            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "CompareProducts");

            migrationBuilder.DropColumn(
                name: "EditDateTime",
                table: "CompareProducts");

            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "EditDateTime",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "EditDateTime",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "CreationDateTime",
                table: "Orders",
                newName: "CreationDatetime");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("36211d90-17e0-42d0-9f3b-3b17d2885ec1"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 23, 9, 14, 52, 447, DateTimeKind.Local).AddTicks(79));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("59d7a46d-79a2-4a09-b6ad-a2333c3d3dcc"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 23, 9, 14, 52, 447, DateTimeKind.Local).AddTicks(71));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8a5cf474-c473-48e1-bc3e-bbe0f22a80f2"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 23, 9, 14, 52, 447, DateTimeKind.Local).AddTicks(39));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("968bfe01-31ba-44c0-a7c8-d1d04c1ffeb5"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 23, 9, 14, 52, 447, DateTimeKind.Local).AddTicks(87));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b41fefb9-1c66-4f2a-86af-090ada282060"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 23, 9, 14, 52, 447, DateTimeKind.Local).AddTicks(75));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e6d46e32-765c-487d-bf57-78759b32a47c"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 23, 9, 14, 52, 447, DateTimeKind.Local).AddTicks(67));
        }
    }
}
