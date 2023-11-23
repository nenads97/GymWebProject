using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class TokenTablesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TokenPrices_Persons_AdministratorId",
                table: "TokenPrices");

            migrationBuilder.AddColumn<int>(
                name: "TokenId",
                table: "TokenPrices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_Purchases_Persons_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientGroupTokens",
                columns: table => new
                {
                    ClientGroupTokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfGroupTokens = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    GroupTokenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientGroupTokens", x => x.ClientGroupTokenId);
                    table.ForeignKey(
                        name: "FK_ClientGroupTokens_Persons_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientPersonalTokens",
                columns: table => new
                {
                    ClientPersonalTokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfPersonalTokens = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    PersonalTokenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPersonalTokens", x => x.ClientPersonalTokenId);
                    table.ForeignKey(
                        name: "FK_ClientPersonalTokens_Persons_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TokenPackages",
                columns: table => new
                {
                    TokenPackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TokenId = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenPackages", x => x.TokenPackageId);
                    table.ForeignKey(
                        name: "FK_TokenPackages_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "PackageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    TokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TokenType = table.Column<int>(type: "int", nullable: false),
                    TokenPackageId = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientGroupTokenId = table.Column<int>(type: "int", nullable: true),
                    ClientPersonalTokenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.TokenId);
                    table.ForeignKey(
                        name: "FK_Tokens_ClientPersonalTokens_ClientPersonalTokenId",
                        column: x => x.ClientPersonalTokenId,
                        principalTable: "ClientPersonalTokens",
                        principalColumn: "ClientPersonalTokenId");
                    table.ForeignKey(
                        name: "FK_Tokens_TokenPackages_TokenPackageId",
                        column: x => x.TokenPackageId,
                        principalTable: "TokenPackages",
                        principalColumn: "TokenPackageId");
                });

            migrationBuilder.CreateTable(
                name: "TokenPurchases",
                columns: table => new
                {
                    TokenPurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    TokenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenPurchases", x => x.TokenPurchaseId);
                    table.ForeignKey(
                        name: "FK_TokenPurchases_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "PurchaseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TokenPurchases_Tokens_TokenId",
                        column: x => x.TokenId,
                        principalTable: "Tokens",
                        principalColumn: "TokenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TokenPrices_TokenId",
                table: "TokenPrices",
                column: "TokenId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientGroupTokens_ClientId",
                table: "ClientGroupTokens",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientGroupTokens_GroupTokenId",
                table: "ClientGroupTokens",
                column: "GroupTokenId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientPersonalTokens_ClientId",
                table: "ClientPersonalTokens",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientPersonalTokens_PersonalTokenId",
                table: "ClientPersonalTokens",
                column: "PersonalTokenId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_ClientId",
                table: "Purchases",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TokenPackages_PackageId",
                table: "TokenPackages",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_TokenPackages_TokenId",
                table: "TokenPackages",
                column: "TokenId");

            migrationBuilder.CreateIndex(
                name: "IX_TokenPurchases_PurchaseId",
                table: "TokenPurchases",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_TokenPurchases_TokenId",
                table: "TokenPurchases",
                column: "TokenId");

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_ClientPersonalTokenId",
                table: "Tokens",
                column: "ClientPersonalTokenId");

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_TokenPackageId",
                table: "Tokens",
                column: "TokenPackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_TokenPrices_Persons_AdministratorId",
                table: "TokenPrices",
                column: "AdministratorId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TokenPrices_Tokens_TokenId",
                table: "TokenPrices",
                column: "TokenId",
                principalTable: "Tokens",
                principalColumn: "TokenId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientGroupTokens_Tokens_GroupTokenId",
                table: "ClientGroupTokens",
                column: "GroupTokenId",
                principalTable: "Tokens",
                principalColumn: "TokenId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientPersonalTokens_Tokens_PersonalTokenId",
                table: "ClientPersonalTokens",
                column: "PersonalTokenId",
                principalTable: "Tokens",
                principalColumn: "TokenId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TokenPackages_Tokens_TokenId",
                table: "TokenPackages",
                column: "TokenId",
                principalTable: "Tokens",
                principalColumn: "TokenId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TokenPrices_Persons_AdministratorId",
                table: "TokenPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_TokenPrices_Tokens_TokenId",
                table: "TokenPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientPersonalTokens_Tokens_PersonalTokenId",
                table: "ClientPersonalTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_TokenPackages_Tokens_TokenId",
                table: "TokenPackages");

            migrationBuilder.DropTable(
                name: "ClientGroupTokens");

            migrationBuilder.DropTable(
                name: "TokenPurchases");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "ClientPersonalTokens");

            migrationBuilder.DropTable(
                name: "TokenPackages");

            migrationBuilder.DropIndex(
                name: "IX_TokenPrices_TokenId",
                table: "TokenPrices");

            migrationBuilder.DropColumn(
                name: "TokenId",
                table: "TokenPrices");

            migrationBuilder.AddForeignKey(
                name: "FK_TokenPrices_Persons_AdministratorId",
                table: "TokenPrices",
                column: "AdministratorId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
