﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Database.Migrations
{
    public partial class AddTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("36211d90-17e0-42d0-9f3b-3b17d2885ec1"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 10, 10, 0, 26, 807, DateTimeKind.Local).AddTicks(9667));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("59d7a46d-79a2-4a09-b6ad-a2333c3d3dcc"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 10, 10, 0, 26, 807, DateTimeKind.Local).AddTicks(9655));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8a5cf474-c473-48e1-bc3e-bbe0f22a80f2"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 10, 10, 0, 26, 806, DateTimeKind.Local).AddTicks(6591));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("968bfe01-31ba-44c0-a7c8-d1d04c1ffeb5"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 10, 10, 0, 26, 807, DateTimeKind.Local).AddTicks(9740));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b41fefb9-1c66-4f2a-86af-090ada282060"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 10, 10, 0, 26, 807, DateTimeKind.Local).AddTicks(9662));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e6d46e32-765c-487d-bf57-78759b32a47c"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 10, 10, 0, 26, 807, DateTimeKind.Local).AddTicks(9610));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("36211d90-17e0-42d0-9f3b-3b17d2885ec1"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 10, 9, 58, 9, 108, DateTimeKind.Local).AddTicks(5069));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("59d7a46d-79a2-4a09-b6ad-a2333c3d3dcc"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 10, 9, 58, 9, 108, DateTimeKind.Local).AddTicks(5058));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8a5cf474-c473-48e1-bc3e-bbe0f22a80f2"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 10, 9, 58, 9, 107, DateTimeKind.Local).AddTicks(2127));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("968bfe01-31ba-44c0-a7c8-d1d04c1ffeb5"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 10, 9, 58, 9, 108, DateTimeKind.Local).AddTicks(5080));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b41fefb9-1c66-4f2a-86af-090ada282060"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 10, 9, 58, 9, 108, DateTimeKind.Local).AddTicks(5064));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e6d46e32-765c-487d-bf57-78759b32a47c"),
                column: "CreationDateTime",
                value: new DateTime(2023, 3, 10, 9, 58, 9, 108, DateTimeKind.Local).AddTicks(5015));
        }
    }
}
