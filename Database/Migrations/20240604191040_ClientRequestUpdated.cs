using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class ClientRequestUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrId",
                table: "ClientRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "ClientRequests",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_ClientRequests_TrainerId",
                table: "ClientRequests",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientRequests_Persons_TrainerId",
                table: "ClientRequests",
                column: "TrainerId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientRequests_Persons_TrainerId",
                table: "ClientRequests");

            migrationBuilder.DropIndex(
                name: "IX_ClientRequests_TrainerId",
                table: "ClientRequests");

            migrationBuilder.DropColumn(
                name: "TrId",
                table: "ClientRequests");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "ClientRequests");

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
        }
    }
}
