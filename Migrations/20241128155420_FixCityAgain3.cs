using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Muresan_Razvan_Lab2.Migrations
{
    /// <inheritdoc />
    public partial class FixCityAgain3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customer_CityID",
                table: "Customer");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CityID",
                table: "Customer",
                column: "CityID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customer_CityID",
                table: "Customer");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CityID",
                table: "Customer",
                column: "CityID",
                unique: true,
                filter: "[CityID] IS NOT NULL");
        }
    }
}
