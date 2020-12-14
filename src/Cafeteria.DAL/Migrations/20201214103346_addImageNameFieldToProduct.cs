using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cafeteria.DAL.Migrations
{
    public partial class addImageNameFieldToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Products",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "MenuDate",
                value: new DateTime(2020, 12, 15, 12, 33, 45, 401, DateTimeKind.Local).AddTicks(4740));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "MenuDate",
                value: new DateTime(2020, 12, 16, 12, 33, 45, 401, DateTimeKind.Local).AddTicks(5423));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 12, 14, 12, 33, 45, 407, DateTimeKind.Local).AddTicks(76));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 12, 14, 12, 33, 45, 407, DateTimeKind.Local).AddTicks(3657));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 12, 14, 12, 33, 45, 407, DateTimeKind.Local).AddTicks(3760));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "FinalDate",
                value: new DateTime(2020, 12, 16, 12, 33, 45, 395, DateTimeKind.Local).AddTicks(2195));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "FinalDate",
                value: new DateTime(2020, 12, 19, 12, 33, 45, 401, DateTimeKind.Local).AddTicks(2640));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "MenuDate",
                value: new DateTime(2020, 11, 7, 22, 41, 45, 856, DateTimeKind.Local).AddTicks(8286));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "MenuDate",
                value: new DateTime(2020, 11, 8, 22, 41, 45, 856, DateTimeKind.Local).AddTicks(9516));

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
    }
}
