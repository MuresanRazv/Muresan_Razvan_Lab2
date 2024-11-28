using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Muresan_Razvan_Lab2.Migrations
{
    /// <inheritdoc />
    public partial class FixedCity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Customer_CustomerId",
                table: "City");

            migrationBuilder.DropIndex(
                name: "IX_City_CustomerId",
                table: "City");
        }
    }
}
