using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentals.Infrastructure.Migrations
{
    public partial class addedCarLoanAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    SSN = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetailsId = table.Column<int>(nullable: false),
                    Mileage = table.Column<int>(nullable: false),
                    RegistrationNumber = table.Column<string>(maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_CarDetails_DetailsId",
                        column: x => x.DetailsId,
                        principalTable: "CarDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarLoans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: false),
                    cost = table.Column<int>(nullable: false),
                    LoanStart = table.Column<DateTime>(nullable: false),
                    LoanEnd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarLoans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarLoans_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarLoans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "DetailsId", "Mileage", "RegistrationNumber" },
                values: new object[,]
                {
                    { 99, 1, 134, "ABC123" },
                    { 2, 2, 600, "BOA123" },
                    { 3, 3, 642, "KIA499" },
                    { 4, 4, 1500, "PYA635" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarLoans_CarId",
                table: "CarLoans",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarLoans_UserId",
                table: "CarLoans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_DetailsId",
                table: "Cars",
                column: "DetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarLoans");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CarDetails");
        }
    }
}
