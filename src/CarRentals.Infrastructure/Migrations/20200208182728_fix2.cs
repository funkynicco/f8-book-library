using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentals.Infrastructure.Migrations
{
    public partial class fix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "MaxRentDays",
                value: 14);

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "MaxRentDays",
                value: 14);

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "MaxRentDays",
                value: 14);

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "MaxRentDays",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Role",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Role",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Role",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Role",
                value: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Role",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Role",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Role",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Role",
                value: "User");
        }
    }
}
