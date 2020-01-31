using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentals.Infrastructure.Migrations
{
    public partial class dsada2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Mileage", "Model", "RegistrationNumber" },
                values: new object[] { 99, 134, "BMW", "ABC123" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Mileage", "Model", "RegistrationNumber" },
                values: new object[] { 1, 134, "BMW", "ABC123" });
        }
    }
}
