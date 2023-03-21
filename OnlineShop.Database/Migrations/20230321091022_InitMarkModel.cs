using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitMarkModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Marks_MarkId",
                table: "Models");

            migrationBuilder.AlterColumn<Guid>(
                name: "MarkId",
                table: "Models",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Marks",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("45e03085-c24d-4a9a-95a6-00d49dbf4bb9"), "Ferrari" },
                    { new Guid("c589375f-897f-45f7-86a2-09011a939695"), "Lamborghini" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("36211d90-17e0-42d0-9f3b-3b17d2885ec1"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 21, 12, 10, 22, 562, DateTimeKind.Local).AddTicks(5080));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("59d7a46d-79a2-4a09-b6ad-a2333c3d3dcc"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 21, 12, 10, 22, 562, DateTimeKind.Local).AddTicks(5072));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8a5cf474-c473-48e1-bc3e-bbe0f22a80f2"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 21, 12, 10, 22, 562, DateTimeKind.Local).AddTicks(5046));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("968bfe01-31ba-44c0-a7c8-d1d04c1ffeb5"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 21, 12, 10, 22, 562, DateTimeKind.Local).AddTicks(5089));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b41fefb9-1c66-4f2a-86af-090ada282060"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 21, 12, 10, 22, 562, DateTimeKind.Local).AddTicks(5076));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e6d46e32-765c-487d-bf57-78759b32a47c"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 21, 12, 10, 22, 562, DateTimeKind.Local).AddTicks(5069));

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "MarkId", "Name" },
                values: new object[,]
                {
                    { new Guid("1e1620e7-abf1-4228-bfc1-d68d44c9fd83"), new Guid("45e03085-c24d-4a9a-95a6-00d49dbf4bb9"), "F560" },
                    { new Guid("e617a298-74b2-42ff-a01d-72a8c1b38f79"), new Guid("c589375f-897f-45f7-86a2-09011a939695"), "Diablo" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Marks_MarkId",
                table: "Models",
                column: "MarkId",
                principalTable: "Marks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Marks_MarkId",
                table: "Models");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("1e1620e7-abf1-4228-bfc1-d68d44c9fd83"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("e617a298-74b2-42ff-a01d-72a8c1b38f79"));

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: new Guid("45e03085-c24d-4a9a-95a6-00d49dbf4bb9"));

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: new Guid("c589375f-897f-45f7-86a2-09011a939695"));

            migrationBuilder.AlterColumn<Guid>(
                name: "MarkId",
                table: "Models",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("36211d90-17e0-42d0-9f3b-3b17d2885ec1"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 20, 13, 9, 23, 703, DateTimeKind.Local).AddTicks(1131));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("59d7a46d-79a2-4a09-b6ad-a2333c3d3dcc"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 20, 13, 9, 23, 703, DateTimeKind.Local).AddTicks(1114));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8a5cf474-c473-48e1-bc3e-bbe0f22a80f2"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 20, 13, 9, 23, 703, DateTimeKind.Local).AddTicks(1047));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("968bfe01-31ba-44c0-a7c8-d1d04c1ffeb5"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 20, 13, 9, 23, 703, DateTimeKind.Local).AddTicks(1146));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b41fefb9-1c66-4f2a-86af-090ada282060"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 20, 13, 9, 23, 703, DateTimeKind.Local).AddTicks(1121));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e6d46e32-765c-487d-bf57-78759b32a47c"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 20, 13, 9, 23, 703, DateTimeKind.Local).AddTicks(1105));

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Marks_MarkId",
                table: "Models",
                column: "MarkId",
                principalTable: "Marks",
                principalColumn: "Id");
        }
    }
}
