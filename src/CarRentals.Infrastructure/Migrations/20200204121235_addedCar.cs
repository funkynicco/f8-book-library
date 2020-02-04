using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentals.Infrastructure.Migrations
{
    public partial class addedCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Model",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "DetailsId",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CarDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDetails", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CarDetails",
                columns: new[] { "Id", "Model" },
                values: new object[,]
                {
                    { 1, "BMW" },
                    { 2, "Audi" },
                    { 3, "Volvo" },
                    { 4, "SAAB" }
                });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "DetailsId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "DetailsId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 99,
                column: "DetailsId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "DetailsId", "Mileage", "RegistrationNumber" },
                values: new object[] { 4, 4, 1500, "PYA635" });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_DetailsId",
                table: "Cars",
                column: "DetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarDetails_DetailsId",
                table: "Cars",
                column: "DetailsId",
                principalTable: "CarDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarDetails_DetailsId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "CarDetails");

            migrationBuilder.DropIndex(
                name: "IX_Cars_DetailsId",
                table: "Cars");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "DetailsId",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Cars",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "Model",
                value: "Audi");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "Model",
                value: "Volvo");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 99,
                column: "Model",
                value: "BMW");
        }
    }
}
