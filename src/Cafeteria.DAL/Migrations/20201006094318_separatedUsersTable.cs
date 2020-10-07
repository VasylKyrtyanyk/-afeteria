using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cafeteria.DAL.Migrations
{
    public partial class separatedUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "MenuDate",
                value: new DateTime(2020, 10, 7, 12, 43, 18, 228, DateTimeKind.Local).AddTicks(8115));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "MenuDate",
                value: new DateTime(2020, 10, 8, 12, 43, 18, 228, DateTimeKind.Local).AddTicks(8840));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 10, 6, 12, 43, 18, 235, DateTimeKind.Local).AddTicks(60));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 10, 6, 12, 43, 18, 235, DateTimeKind.Local).AddTicks(4270));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "FinalDate",
                value: new DateTime(2020, 10, 8, 12, 43, 18, 224, DateTimeKind.Local).AddTicks(8095));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "FinalDate",
                value: new DateTime(2020, 10, 11, 12, 43, 18, 228, DateTimeKind.Local).AddTicks(6742));

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Balance", "DateOfBirth", "FirstName", "LastName", "UserId" },
                values: new object[,]
                {
                    { 1, 0m, new DateTime(1999, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrii", null, 1 },
                    { 2, 0m, new DateTime(1998, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vasyl", null, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserId",
                table: "UserProfiles",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Users",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "MenuDate",
                value: new DateTime(2020, 10, 7, 12, 38, 13, 545, DateTimeKind.Local).AddTicks(7188));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "MenuDate",
                value: new DateTime(2020, 10, 8, 12, 38, 13, 545, DateTimeKind.Local).AddTicks(7931));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 10, 6, 12, 38, 13, 550, DateTimeKind.Local).AddTicks(4058));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 10, 6, 12, 38, 13, 550, DateTimeKind.Local).AddTicks(6840));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "FinalDate",
                value: new DateTime(2020, 10, 8, 12, 38, 13, 540, DateTimeKind.Local).AddTicks(7224));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "FinalDate",
                value: new DateTime(2020, 10, 11, 12, 38, 13, 545, DateTimeKind.Local).AddTicks(5544));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfBirth", "FirstName", "UserId" },
                values: new object[] { new DateTime(1999, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrii", 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfBirth", "FirstName", "UserId" },
                values: new object[] { new DateTime(1998, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vasyl", 2 });
        }
    }
}
