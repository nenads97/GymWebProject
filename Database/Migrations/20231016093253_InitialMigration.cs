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
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
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
                        name: "FK_PackageAdministrators_Persons_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "TokenPrices",
                columns: table => new
                {
                    TokenPriceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdministratorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenPrices", x => x.TokenPriceId);
                    table.ForeignKey(
                        name: "FK_TokenPrices_Persons_AdministratorId",
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
                    PackageAdministratorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.PackageId);
                    table.ForeignKey(
                        name: "FK_Packages_PackageAdministrators_PackageAdministratorId",
                        column: x => x.PackageAdministratorId,
                        principalTable: "PackageAdministrators",
                        principalColumn: "PackageAdministratorId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Discriminator", "Email", "Firstname", "Gender", "JMBG", "Password", "PhoneNumber", "Role", "Surname", "Username" },
                values: new object[] { 1, "Administrator", "nenad.suknovic@gmail.com", "Nenad", 0, 1001997800095L, "admin", 613618201.0, 0, "Suknovic", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_PackageAdministrators_AdministratorId",
                table: "PackageAdministrators",
                column: "AdministratorId");

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
                name: "IX_Packages_PackageAdministratorId",
                table: "Packages",
                column: "PackageAdministratorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TokenPrices_AdministratorId",
                table: "TokenPrices",
                column: "AdministratorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackagePackageDiscounts");

            migrationBuilder.DropTable(
                name: "PackagePrices");

            migrationBuilder.DropTable(
                name: "TokenPrices");

            migrationBuilder.DropTable(
                name: "PackageDiscounts");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "PackageAdministrators");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
