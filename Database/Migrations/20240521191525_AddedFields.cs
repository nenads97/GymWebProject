using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddedFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Trainings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "numberOfReservedSpots",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 5, 21, 21, 15, 24, 185, DateTimeKind.Local).AddTicks(7845));

            migrationBuilder.UpdateData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 5, 21, 21, 15, 24, 185, DateTimeKind.Local).AddTicks(7889));

            migrationBuilder.UpdateData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 5, 21, 21, 15, 24, 185, DateTimeKind.Local).AddTicks(7894));

            migrationBuilder.UpdateData(
                table: "TokenPrices",
                keyColumn: "TokenPriceId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 5, 21, 21, 15, 24, 185, DateTimeKind.Local).AddTicks(7938));

            migrationBuilder.UpdateData(
                table: "TokenPrices",
                keyColumn: "TokenPriceId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 5, 21, 21, 15, 24, 185, DateTimeKind.Local).AddTicks(7943));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "numberOfReservedSpots",
                table: "Applications");

            migrationBuilder.UpdateData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 5, 21, 20, 42, 14, 236, DateTimeKind.Local).AddTicks(5550));

            migrationBuilder.UpdateData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 5, 21, 20, 42, 14, 236, DateTimeKind.Local).AddTicks(5595));

            migrationBuilder.UpdateData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 5, 21, 20, 42, 14, 236, DateTimeKind.Local).AddTicks(5599));

            migrationBuilder.UpdateData(
                table: "TokenPrices",
                keyColumn: "TokenPriceId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 5, 21, 20, 42, 14, 236, DateTimeKind.Local).AddTicks(5634));

            migrationBuilder.UpdateData(
                table: "TokenPrices",
                keyColumn: "TokenPriceId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 5, 21, 20, 42, 14, 236, DateTimeKind.Local).AddTicks(5643));
        }
    }
}
