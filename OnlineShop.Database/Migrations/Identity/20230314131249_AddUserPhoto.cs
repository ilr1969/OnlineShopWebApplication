using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Database.Migrations.Identity
{
    public partial class AddUserPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Image",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Image_UserId",
                table: "Image",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_AspNetUsers_UserId",
                table: "Image",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_AspNetUsers_UserId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_UserId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Image");
        }
    }
}
