using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentals.Infrastructure.Migrations
{
    public partial class change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNumber",
                table: "Cars",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Cars",
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Mileage", "Model", "RegistrationNumber" },
                values: new object[] { 1, 134, "BMW", "ABC123" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Mileage", "Model", "RegistrationNumber" },
                values: new object[] { 2, 351, "Audi", "BOA123" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Mileage", "Model", "RegistrationNumber" },
                values: new object[] { 3, 642, "Volvo", "KIA499" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNumber",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 16,
                oldNullable: true);
        }
    }
}
