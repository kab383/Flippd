using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flippd.Data.Migrations
{
    public partial class EightCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Users_UserEntityId",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_UserEntityId",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Listings");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Listings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Listings_UserId",
                table: "Listings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Users_UserId",
                table: "Listings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Users_UserId",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_UserId",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Listings");

            migrationBuilder.AddColumn<int>(
                name: "UserEntityId",
                table: "Listings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Listings_UserEntityId",
                table: "Listings",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Users_UserEntityId",
                table: "Listings",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
