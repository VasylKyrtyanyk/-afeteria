using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cafeteria.DAL.Migrations
{
    public partial class dataSeedUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "MenuDate",
                value: new DateTime(2020, 10, 7, 13, 46, 51, 985, DateTimeKind.Local).AddTicks(2200));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "MenuDate",
                value: new DateTime(2020, 10, 8, 13, 46, 51, 985, DateTimeKind.Local).AddTicks(2704));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 10, 6, 13, 46, 51, 989, DateTimeKind.Local).AddTicks(2552));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "PaymentType" },
                values: new object[] { new DateTime(2020, 10, 6, 13, 46, 51, 989, DateTimeKind.Local).AddTicks(5140), 2 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CompletedDate", "CreatedDate", "IsTakeAway", "OrderStatus", "PaymentType", "TotalSum", "UserId" },
                values: new object[] { 3, null, new DateTime(2020, 10, 6, 13, 46, 51, 989, DateTimeKind.Local).AddTicks(5253), true, 0, 1, 155.5m, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "FinalDate",
                value: new DateTime(2020, 10, 8, 13, 46, 51, 982, DateTimeKind.Local).AddTicks(3346));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "FinalDate",
                value: new DateTime(2020, 10, 11, 13, 46, 51, 985, DateTimeKind.Local).AddTicks(1191));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

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
                columns: new[] { "CreatedDate", "PaymentType" },
                values: new object[] { new DateTime(2020, 10, 6, 12, 43, 18, 235, DateTimeKind.Local).AddTicks(4270), 1 });

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
        }
    }
}
