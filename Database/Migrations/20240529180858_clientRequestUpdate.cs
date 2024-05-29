using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class clientRequestUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Requests_ClientRequestId",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Trainings",
                newName: "Status");

            migrationBuilder.AlterColumn<int>(
                name: "ClientRequestId",
                table: "Requests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 5, 29, 20, 8, 56, 977, DateTimeKind.Local).AddTicks(4526));

            migrationBuilder.UpdateData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 5, 29, 20, 8, 56, 977, DateTimeKind.Local).AddTicks(4568));

            migrationBuilder.UpdateData(
                table: "PackagePrices",
                keyColumn: "PackagePriceId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 5, 29, 20, 8, 56, 977, DateTimeKind.Local).AddTicks(4572));

            migrationBuilder.UpdateData(
                table: "TokenPrices",
                keyColumn: "TokenPriceId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 5, 29, 20, 8, 56, 977, DateTimeKind.Local).AddTicks(4653));

            migrationBuilder.UpdateData(
                table: "TokenPrices",
                keyColumn: "TokenPriceId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 5, 29, 20, 8, 56, 977, DateTimeKind.Local).AddTicks(4658));

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ClientRequestId",
                table: "Requests",
                column: "ClientRequestId",
                unique: true,
                filter: "[ClientRequestId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Requests_ClientRequestId",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Trainings",
                newName: "status");

            migrationBuilder.AlterColumn<int>(
                name: "ClientRequestId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ClientRequestId",
                table: "Requests",
                column: "ClientRequestId",
                unique: true);
        }
    }
}
