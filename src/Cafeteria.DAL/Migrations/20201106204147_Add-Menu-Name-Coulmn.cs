using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cafeteria.DAL.Migrations
{
    public partial class AddMenuNameCoulmn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Menus",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MenuDate", "Name" },
                values: new object[] { new DateTime(2020, 11, 7, 22, 41, 45, 856, DateTimeKind.Local).AddTicks(8286), "Some name" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MenuDate", "Name" },
                values: new object[] { new DateTime(2020, 11, 8, 22, 41, 45, 856, DateTimeKind.Local).AddTicks(9516), "Some name" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 6, 22, 41, 45, 865, DateTimeKind.Local).AddTicks(4901));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 6, 22, 41, 45, 866, DateTimeKind.Local).AddTicks(323));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 6, 22, 41, 45, 866, DateTimeKind.Local).AddTicks(463));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "FinalDate",
                value: new DateTime(2020, 11, 8, 22, 41, 45, 849, DateTimeKind.Local).AddTicks(9387));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "FinalDate",
                value: new DateTime(2020, 11, 11, 22, 41, 45, 856, DateTimeKind.Local).AddTicks(4053));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Menus");

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
    }
}
