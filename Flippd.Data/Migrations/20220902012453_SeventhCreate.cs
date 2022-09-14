using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flippd.Data.Migrations
{
    public partial class SeventhCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Listings_PropertyFeaturesId",
                table: "Listings",
                column: "PropertyFeaturesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_PropertyFeatures_PropertyFeaturesId",
                table: "Listings",
                column: "PropertyFeaturesId",
                principalTable: "PropertyFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_PropertyFeatures_PropertyFeaturesId",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_PropertyFeaturesId",
                table: "Listings");
        }
    }
}
