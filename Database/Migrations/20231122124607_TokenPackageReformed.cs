using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class TokenPackageReformed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TokenPackages_Packages_PackageId",
                table: "TokenPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_TokenPackages_Tokens_TokenId",
                table: "TokenPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_Tokens_TokenPackages_TokenPackageId",
                table: "Tokens");

            migrationBuilder.RenameColumn(
                name: "TokenPackageId",
                table: "Tokens",
                newName: "PackageId");

            migrationBuilder.RenameIndex(
                name: "IX_Tokens_TokenPackageId",
                table: "Tokens",
                newName: "IX_Tokens_PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_TokenPackages_Packages_PackageId",
                table: "TokenPackages",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "PackageId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TokenPackages_Tokens_TokenId",
                table: "TokenPackages",
                column: "TokenId",
                principalTable: "Tokens",
                principalColumn: "TokenId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tokens_Packages_PackageId",
                table: "Tokens",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "PackageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TokenPackages_Packages_PackageId",
                table: "TokenPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_TokenPackages_Tokens_TokenId",
                table: "TokenPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_Tokens_Packages_PackageId",
                table: "Tokens");

            migrationBuilder.RenameColumn(
                name: "PackageId",
                table: "Tokens",
                newName: "TokenPackageId");

            migrationBuilder.RenameIndex(
                name: "IX_Tokens_PackageId",
                table: "Tokens",
                newName: "IX_Tokens_TokenPackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_TokenPackages_Packages_PackageId",
                table: "TokenPackages",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "PackageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TokenPackages_Tokens_TokenId",
                table: "TokenPackages",
                column: "TokenId",
                principalTable: "Tokens",
                principalColumn: "TokenId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tokens_TokenPackages_TokenPackageId",
                table: "Tokens",
                column: "TokenPackageId",
                principalTable: "TokenPackages",
                principalColumn: "TokenPackageId");
        }
    }
}
