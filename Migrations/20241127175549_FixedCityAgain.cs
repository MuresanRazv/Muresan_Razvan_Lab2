using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Muresan_Razvan_Lab2.Migrations
{
    /// <inheritdoc />
    public partial class FixedCityAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Customer_CustomerId",
                table: "City");

            migrationBuilder.DropIndex(
                name: "IX_City_CustomerId",
                table: "City");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "City");

            migrationBuilder.AddColumn<int>(
                name: "CityID",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CityID",
                table: "Customer",
                column: "CityID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_City_CityID",
                table: "Customer",
                column: "CityID",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_City_CityID",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_CityID",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CityID",
                table: "Customer");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "City",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_City_CustomerId",
                table: "City",
                column: "CustomerId",
                unique: true,
                filter: "[CustomerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_City_Customer_CustomerId",
                table: "City",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerID");
        }
    }
}
