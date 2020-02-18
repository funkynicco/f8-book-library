using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentals.Infrastructure.Migrations
{
    public partial class renamemodeltomake : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Model",
                table: "CarDetails");

            migrationBuilder.AddColumn<string>(
                name: "Make",
                table: "CarDetails",
                maxLength: 16,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Make", "MaxRentDays" },
                values: new object[] { "BMW 335D", 14 });

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Make", "MaxRentDays" },
                values: new object[] { "Audi A6 Quattro", 14 });

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Make", "MaxRentDays" },
                values: new object[] { "Volvo V70", 14 });

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Make", "MaxRentDays" },
                values: new object[] { "SAAB 9-3", 14 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "CostPerDay",
                value: 2500);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "CostPerDay",
                value: 2200);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "CostPerDay",
                value: 900);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 99,
                column: "CostPerDay",
                value: 2000);

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
            migrationBuilder.DropColumn(
                name: "Make",
                table: "CarDetails");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "CarDetails",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MaxRentDays", "Model" },
                values: new object[] { 14, "BMW 335D" });

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MaxRentDays", "Model" },
                values: new object[] { 14, "Audi A6 Quattro" });

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "MaxRentDays", "Model" },
                values: new object[] { 14, "Volvo V70" });

            migrationBuilder.UpdateData(
                table: "CarDetails",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "MaxRentDays", "Model" },
                values: new object[] { 14, "SAAB 9-3" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "CostPerDay",
                value: 1500);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "CostPerDay",
                value: 1200);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "CostPerDay",
                value: 800);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 99,
                column: "CostPerDay",
                value: 1000);

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
