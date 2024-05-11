using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 4, 23, 18, 10, 0, 779, DateTimeKind.Local).AddTicks(4346));

            migrationBuilder.UpdateData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 4, 23, 18, 10, 0, 779, DateTimeKind.Local).AddTicks(4384));

            migrationBuilder.UpdateData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 4, 23, 18, 10, 0, 779, DateTimeKind.Local).AddTicks(4387));

            migrationBuilder.InsertData(
                table: "TokenPackages",
                columns: new[] { "TokenPackageId", "PackageId", "Quantity", "TokenId" },
                values: new object[,]
                {
                    { 1, 1, 0, 1 },
                    { 2, 1, 0, 1 },
                    { 3, 2, 10, 2 },
                    { 4, 2, 0, 1 },
                    { 5, 3, 10, 1 },
                    { 6, 3, 10, 2 }
                });

            migrationBuilder.InsertData(
                table: "TokenPrices",
                columns: new[] { "TokenPriceId", "AdministratorId", "Date", "TokenId", "Value" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 4, 23, 18, 10, 0, 779, DateTimeKind.Local).AddTicks(4434), 1, 1000.0 },
                    { 2, 1, new DateTime(2024, 4, 23, 18, 10, 0, 779, DateTimeKind.Local).AddTicks(4439), 2, 500.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TokenPackages",
                keyColumn: "TokenPackageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TokenPackages",
                keyColumn: "TokenPackageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TokenPackages",
                keyColumn: "TokenPackageId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TokenPackages",
                keyColumn: "TokenPackageId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TokenPackages",
                keyColumn: "TokenPackageId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TokenPackages",
                keyColumn: "TokenPackageId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TokenPrices",
                keyColumn: "TokenPriceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TokenPrices",
                keyColumn: "TokenPriceId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 4, 23, 17, 45, 24, 174, DateTimeKind.Local).AddTicks(1579));

            migrationBuilder.UpdateData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 4, 23, 17, 45, 24, 174, DateTimeKind.Local).AddTicks(1617));

            migrationBuilder.UpdateData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 4, 23, 17, 45, 24, 174, DateTimeKind.Local).AddTicks(1621));
        }
    }
}
