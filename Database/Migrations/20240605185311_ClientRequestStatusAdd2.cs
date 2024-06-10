using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class ClientRequestStatusAdd2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 5, 20, 53, 10, 675, DateTimeKind.Local).AddTicks(3357));

            migrationBuilder.UpdateData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 6, 5, 20, 53, 10, 675, DateTimeKind.Local).AddTicks(3394));

            migrationBuilder.UpdateData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 6, 5, 20, 53, 10, 675, DateTimeKind.Local).AddTicks(3398));

            migrationBuilder.UpdateData(
                table: "TokenPrices",
                keyColumn: "TokenPriceId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 5, 20, 53, 10, 675, DateTimeKind.Local).AddTicks(3442));

            migrationBuilder.UpdateData(
                table: "TokenPrices",
                keyColumn: "TokenPriceId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 6, 5, 20, 53, 10, 675, DateTimeKind.Local).AddTicks(3447));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
