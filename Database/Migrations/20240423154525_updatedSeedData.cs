using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class updatedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "PackageId", "AdministratorId", "PackageName" },
                values: new object[,]
                {
                    { 1, 1, "Silver" },
                    { 2, 1, "Gold" },
                    { 3, 1, "Premium" }
                });

            migrationBuilder.InsertData(
                table: "PackagePrices",
                columns: new[] { "PackagePriceId", "AdministratorId", "Date", "PackageId", "Value" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 4, 23, 17, 45, 24, 174, DateTimeKind.Local).AddTicks(1579), 1, 3000.0 },
                    { 2, 1, new DateTime(2024, 4, 23, 17, 45, 24, 174, DateTimeKind.Local).AddTicks(1617), 2, 4500.0 },
                    { 3, 1, new DateTime(2024, 4, 23, 17, 45, 24, 174, DateTimeKind.Local).AddTicks(1621), 3, 8000.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 3);
        }
    }
}
