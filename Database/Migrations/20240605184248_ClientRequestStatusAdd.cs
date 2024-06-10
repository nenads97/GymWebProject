using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class ClientRequestStatusAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 5, 20, 42, 47, 846, DateTimeKind.Local).AddTicks(8204));

            migrationBuilder.UpdateData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 6, 5, 20, 42, 47, 846, DateTimeKind.Local).AddTicks(8243));

            migrationBuilder.UpdateData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 6, 5, 20, 42, 47, 846, DateTimeKind.Local).AddTicks(8247));

            migrationBuilder.UpdateData(
                table: "TokenPrices",
                keyColumn: "TokenPriceId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 5, 20, 42, 47, 846, DateTimeKind.Local).AddTicks(8291));

            migrationBuilder.UpdateData(
                table: "TokenPrices",
                keyColumn: "TokenPriceId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 6, 5, 20, 42, 47, 846, DateTimeKind.Local).AddTicks(8295));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Requests");

            migrationBuilder.UpdateData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 4, 21, 10, 39, 319, DateTimeKind.Local).AddTicks(4614));

            migrationBuilder.UpdateData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 6, 4, 21, 10, 39, 319, DateTimeKind.Local).AddTicks(4652));

            migrationBuilder.UpdateData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 6, 4, 21, 10, 39, 319, DateTimeKind.Local).AddTicks(4656));

            migrationBuilder.UpdateData(
                table: "TokenPrices",
                keyColumn: "TokenPriceId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 4, 21, 10, 39, 319, DateTimeKind.Local).AddTicks(4695));

            migrationBuilder.UpdateData(
                table: "TokenPrices",
                keyColumn: "TokenPriceId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 6, 4, 21, 10, 39, 319, DateTimeKind.Local).AddTicks(4699));
        }
    }
}
