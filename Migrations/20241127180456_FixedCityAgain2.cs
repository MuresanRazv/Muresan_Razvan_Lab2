using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Muresan_Razvan_Lab2.Migrations
{
    /// <inheritdoc />
    public partial class FixedCityAgain2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_City_CityID",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_CityID",
                table: "Customer");

            migrationBuilder.AlterColumn<int>(
                name: "CityID",
                table: "Customer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CityID",
                table: "Customer",
                column: "CityID",
                unique: true,
                filter: "[CityID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_City_CityID",
                table: "Customer",
                column: "CityID",
                principalTable: "City",
                principalColumn: "Id");
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

            migrationBuilder.AlterColumn<int>(
                name: "CityID",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
