using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class TokenPackageCardinalityChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tokens_Packages_PackageId",
                table: "Tokens");

            migrationBuilder.DropIndex(
                name: "IX_Tokens_PackageId",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "Tokens");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PackageId",
                table: "Tokens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_PackageId",
                table: "Tokens",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tokens_Packages_PackageId",
                table: "Tokens",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "PackageId");
        }
    }
}
