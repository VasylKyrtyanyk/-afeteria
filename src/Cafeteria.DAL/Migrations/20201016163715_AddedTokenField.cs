using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cafeteria.DAL.Migrations
{
    public partial class AddedTokenField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Users",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "MenuDate",
                value: new DateTime(2020, 10, 17, 19, 37, 14, 545, DateTimeKind.Local).AddTicks(7962));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "MenuDate",
                value: new DateTime(2020, 10, 18, 19, 37, 14, 545, DateTimeKind.Local).AddTicks(8456));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 10, 16, 19, 37, 14, 549, DateTimeKind.Local).AddTicks(3935));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 10, 16, 19, 37, 14, 549, DateTimeKind.Local).AddTicks(6470));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 10, 16, 19, 37, 14, 549, DateTimeKind.Local).AddTicks(6546));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "FinalDate",
                value: new DateTime(2020, 10, 18, 19, 37, 14, 543, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "FinalDate",
                value: new DateTime(2020, 10, 21, 19, 37, 14, 545, DateTimeKind.Local).AddTicks(6981));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "MenuDate",
                value: new DateTime(2020, 10, 7, 14, 23, 21, 422, DateTimeKind.Local).AddTicks(1305));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "MenuDate",
                value: new DateTime(2020, 10, 8, 14, 23, 21, 422, DateTimeKind.Local).AddTicks(2334));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 10, 6, 14, 23, 21, 428, DateTimeKind.Local).AddTicks(6121));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 10, 6, 14, 23, 21, 428, DateTimeKind.Local).AddTicks(9993));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 10, 6, 14, 23, 21, 429, DateTimeKind.Local).AddTicks(119));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "FinalDate",
                value: new DateTime(2020, 10, 8, 14, 23, 21, 416, DateTimeKind.Local).AddTicks(2968));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "FinalDate",
                value: new DateTime(2020, 10, 11, 14, 23, 21, 421, DateTimeKind.Local).AddTicks(9178));
        }
    }
}
