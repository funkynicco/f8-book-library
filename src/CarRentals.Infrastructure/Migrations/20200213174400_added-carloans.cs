using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentals.Infrastructure.Migrations
{
    public partial class addedcarloans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarLoans");

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: false),
                    Cost = table.Column<int>(nullable: false),
                    LoanStart = table.Column<DateTime>(nullable: false),
                    LoanEnd = table.Column<DateTime>(nullable: false),
                    CarReturned = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loans_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLoans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    LoanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLoans_Loans_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserLoans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Loans_CarId",
                table: "Loans",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_UserId",
                table: "Loans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLoans_LoanId",
                table: "UserLoans",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLoans_UserId",
                table: "UserLoans",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLoans");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.CreateTable(
                name: "CarLoans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    CarReturned = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    LoanEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoanStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_CarLoans_CarId",
                table: "CarLoans",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarLoans_UserId",
                table: "CarLoans",
                column: "UserId");
        }
    }
}
