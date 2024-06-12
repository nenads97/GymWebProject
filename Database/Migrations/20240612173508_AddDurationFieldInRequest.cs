using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddDurationFieldInRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 12, 19, 35, 7, 571, DateTimeKind.Local).AddTicks(6176));

            migrationBuilder.UpdateData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 6, 12, 19, 35, 7, 571, DateTimeKind.Local).AddTicks(6217));

            migrationBuilder.UpdateData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 6, 12, 19, 35, 7, 571, DateTimeKind.Local).AddTicks(6221));

            migrationBuilder.UpdateData(
                table: "TokenPrices",
                keyColumn: "TokenPriceId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 12, 19, 35, 7, 571, DateTimeKind.Local).AddTicks(6264));

            migrationBuilder.UpdateData(
                table: "TokenPrices",
                keyColumn: "TokenPriceId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 6, 12, 19, 35, 7, 571, DateTimeKind.Local).AddTicks(6268));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Requests");

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
    }
}
