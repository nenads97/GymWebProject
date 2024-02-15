using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JMBG = table.Column<long>(type: "bigint", nullable: false),
                    PhoneNumber = table.Column<double>(type: "float", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackageDiscounts",
                columns: table => new
                {
                    PackageDiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    AdministratorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageDiscounts", x => x.PackageDiscountId);
                    table.ForeignKey(
                        name: "FK_PackageDiscounts_Persons_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    PackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdministratorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.PackageId);
                    table.ForeignKey(
                        name: "FK_Packages_Persons_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Persons_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_Persons_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "Tokens",
                columns: table => new
                {
                    TokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TokenType = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupToken_ClientId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.TokenId);
                    table.ForeignKey(
                        name: "FK_Tokens_Persons_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tokens_Persons_GroupToken_ClientId",
                        column: x => x.GroupToken_ClientId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    MembershipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.MembershipId);
                    table.ForeignKey(
                        name: "FK_Memberships_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "PackageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Memberships_Persons_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PackageAdministrators",
                columns: table => new
                {
                    PackageAdministratorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdministratorId = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageAdministrators", x => x.PackageAdministratorId);
                    table.ForeignKey(
                        name: "FK_PackageAdministrators_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "PackageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PackageAdministrators_Persons_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PackagePackageDiscounts",
                columns: table => new
                {
                    PackagePackageDiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageDiscountId = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackagePackageDiscounts", x => x.PackagePackageDiscountId);
                    table.ForeignKey(
                        name: "FK_PackagePackageDiscounts_PackageDiscounts_PackageDiscountId",
                        column: x => x.PackageDiscountId,
                        principalTable: "PackageDiscounts",
                        principalColumn: "PackageDiscountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PackagePackageDiscounts_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "PackageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PackagePrices",
                columns: table => new
                {
                    PackagePriceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdministratorId = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackagePrices", x => x.PackagePriceId);
                    table.ForeignKey(
                        name: "FK_PackagePrices_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "PackageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PackagePrices_Persons_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientGroupTokens_Tokens_GroupTokenId",
                        column: x => x.GroupTokenId,
                        principalTable: "Tokens",
                        principalColumn: "TokenId",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientPersonalTokens_Tokens_PersonalTokenId",
                        column: x => x.PersonalTokenId,
                        principalTable: "Tokens",
                        principalColumn: "TokenId",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TokenPackages_Tokens_TokenId",
                        column: x => x.TokenId,
                        principalTable: "Tokens",
                        principalColumn: "TokenId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TokenPrices",
                columns: table => new
                {
                    TokenPriceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdministratorId = table.Column<int>(type: "int", nullable: false),
                    TokenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenPrices", x => x.TokenPriceId);
                    table.ForeignKey(
                        name: "FK_TokenPrices_Persons_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TokenPrices_Tokens_TokenId",
                        column: x => x.TokenId,
                        principalTable: "Tokens",
                        principalColumn: "TokenId",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Discriminator", "Email", "Firstname", "Gender", "JMBG", "Password", "PhoneNumber", "Role", "Surname", "Username" },
                values: new object[] { 1, "Administrator", "nenad.suknovic@gmail.com", "Nenad", 0, 1001997800095L, "admin", 613618201.0, 0, "Suknovic", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_ClientGroupTokens_ClientId",
                table: "ClientGroupTokens",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientGroupTokens_GroupTokenId",
                table: "ClientGroupTokens",
                column: "GroupTokenId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientPersonalTokens_ClientId",
                table: "ClientPersonalTokens",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientPersonalTokens_PersonalTokenId",
                table: "ClientPersonalTokens",
                column: "PersonalTokenId");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_ClientId",
                table: "Memberships",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_PackageId",
                table: "Memberships",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageAdministrators_AdministratorId",
                table: "PackageAdministrators",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageAdministrators_PackageId",
                table: "PackageAdministrators",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageDiscounts_AdministratorId",
                table: "PackageDiscounts",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_PackagePackageDiscounts_PackageDiscountId",
                table: "PackagePackageDiscounts",
                column: "PackageDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_PackagePackageDiscounts_PackageId",
                table: "PackagePackageDiscounts",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PackagePrices_AdministratorId",
                table: "PackagePrices",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_PackagePrices_PackageId",
                table: "PackagePrices",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_AdministratorId",
                table: "Packages",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ClientId",
                table: "Payments",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_EmployeeId",
                table: "Payments",
                column: "EmployeeId");

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
                name: "IX_TokenPrices_AdministratorId",
                table: "TokenPrices",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_TokenPrices_TokenId",
                table: "TokenPrices",
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
                name: "IX_Tokens_ClientId",
                table: "Tokens",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_GroupToken_ClientId",
                table: "Tokens",
                column: "GroupToken_ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientGroupTokens");

            migrationBuilder.DropTable(
                name: "ClientPersonalTokens");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "PackageAdministrators");

            migrationBuilder.DropTable(
                name: "PackagePackageDiscounts");

            migrationBuilder.DropTable(
                name: "PackagePrices");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "TokenPackages");

            migrationBuilder.DropTable(
                name: "TokenPrices");

            migrationBuilder.DropTable(
                name: "TokenPurchases");

            migrationBuilder.DropTable(
                name: "PackageDiscounts");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
