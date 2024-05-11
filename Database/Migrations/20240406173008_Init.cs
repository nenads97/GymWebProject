using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
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
                name: "ClientRequests",
                columns: table => new
                {
                    ClientRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTimeOfSubmission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientRequests", x => x.ClientRequestId);
                    table.ForeignKey(
                        name: "FK_ClientRequests_Persons_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "TrainerTrainingSignOuts",
                columns: table => new
                {
                    TrainerTrainingSignOutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DafeOfSignOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrainerId = table.Column<int>(type: "int", nullable: false),
                    TrainingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerTrainingSignOuts", x => x.TrainerTrainingSignOutId);
                    table.ForeignKey(
                        name: "FK_TrainerTrainingSignOuts_Persons_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainerTrainingSignUps",
                columns: table => new
                {
                    IdTrenerTreningZakazivanje = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumZakazivanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrainerId = table.Column<int>(type: "int", nullable: false),
                    TrainingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerTrainingSignUps", x => x.IdTrenerTreningZakazivanje);
                    table.ForeignKey(
                        name: "FK_TrainerTrainingSignUps_Persons_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAndTimeOfRequestOpening = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientRequestId = table.Column<int>(type: "int", nullable: false),
                    ResponseId = table.Column<int>(type: "int", nullable: true),
                    PersonalTrainingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_Requests_ClientRequests_ClientRequestId",
                        column: x => x.ClientRequestId,
                        principalTable: "ClientRequests",
                        principalColumn: "ClientRequestId",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    ResponseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<bool>(type: "bit", nullable: false),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    TrainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.ResponseId);
                    table.ForeignKey(
                        name: "FK_Responses_Persons_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Responses_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OpeningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    numberOfSpots = table.Column<int>(type: "int", nullable: false),
                    GroupTrainingId = table.Column<int>(type: "int", nullable: false),
                    TrainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_Applications_Persons_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SignOutsFromTraining",
                columns: table => new
                {
                    SignOutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTimeOfSignOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignOutsFromTraining", x => x.SignOutId);
                    table.ForeignKey(
                        name: "FK_SignOutsFromTraining_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SignOutsFromTraining_Persons_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SignUpsForTraining",
                columns: table => new
                {
                    SignUpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTimeOfSignUp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignUpsForTraining", x => x.SignUpId);
                    table.ForeignKey(
                        name: "FK_SignUpsForTraining_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SignUpsForTraining_Persons_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    TrainingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingType = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainerId = table.Column<int>(type: "int", nullable: false),
                    TrainerTrainingSignOutId = table.Column<int>(type: "int", nullable: false),
                    TrainerTrainingSignUpId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SignUpId = table.Column<int>(type: "int", nullable: true),
                    RequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.TrainingId);
                    table.ForeignKey(
                        name: "FK_Training_Persons_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Training_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "RequestId");
                    table.ForeignKey(
                        name: "FK_Training_SignUpsForTraining_SignUpId",
                        column: x => x.SignUpId,
                        principalTable: "SignUpsForTraining",
                        principalColumn: "SignUpId");
                    table.ForeignKey(
                        name: "FK_Training_TrainerTrainingSignOuts_TrainerTrainingSignOutId",
                        column: x => x.TrainerTrainingSignOutId,
                        principalTable: "TrainerTrainingSignOuts",
                        principalColumn: "TrainerTrainingSignOutId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Training_TrainerTrainingSignUps_TrainerTrainingSignUpId",
                        column: x => x.TrainerTrainingSignUpId,
                        principalTable: "TrainerTrainingSignUps",
                        principalColumn: "IdTrenerTreningZakazivanje",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GTokenGTraining",
                columns: table => new
                {
                    GTrainingGTokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GroupTrainingId = table.Column<int>(type: "int", nullable: false),
                    GroupTokenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GTokenGTraining", x => x.GTrainingGTokenId);
                    table.ForeignKey(
                        name: "FK_GTokenGTraining_Tokens_GroupTokenId",
                        column: x => x.GroupTokenId,
                        principalTable: "Tokens",
                        principalColumn: "TokenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GTokenGTraining_Training_GroupTrainingId",
                        column: x => x.GroupTrainingId,
                        principalTable: "Training",
                        principalColumn: "TrainingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PTokenPTraining",
                columns: table => new
                {
                    PTokenPTrainingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonalTrainingId = table.Column<int>(type: "int", nullable: false),
                    PersonalTokenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PTokenPTraining", x => x.PTokenPTrainingId);
                    table.ForeignKey(
                        name: "FK_PTokenPTraining_Tokens_PersonalTokenId",
                        column: x => x.PersonalTokenId,
                        principalTable: "Tokens",
                        principalColumn: "TokenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PTokenPTraining_Training_PersonalTrainingId",
                        column: x => x.PersonalTrainingId,
                        principalTable: "Training",
                        principalColumn: "TrainingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Discriminator", "Email", "Firstname", "Gender", "JMBG", "Password", "PhoneNumber", "Role", "Surname", "Username" },
                values: new object[] { 1, "Administrator", "nenad.suknovic@gmail.com", "Nenad", 0, 1001997800095L, "admin", 613618201.0, 0, "Suknovic", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_GroupTrainingId",
                table: "Applications",
                column: "GroupTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_TrainerId",
                table: "Applications",
                column: "TrainerId");

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
                name: "IX_ClientRequests_ClientId",
                table: "ClientRequests",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_GTokenGTraining_GroupTokenId",
                table: "GTokenGTraining",
                column: "GroupTokenId");

            migrationBuilder.CreateIndex(
                name: "IX_GTokenGTraining_GroupTrainingId",
                table: "GTokenGTraining",
                column: "GroupTrainingId");

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
                name: "IX_PTokenPTraining_PersonalTokenId",
                table: "PTokenPTraining",
                column: "PersonalTokenId");

            migrationBuilder.CreateIndex(
                name: "IX_PTokenPTraining_PersonalTrainingId",
                table: "PTokenPTraining",
                column: "PersonalTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_ClientId",
                table: "Purchases",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ClientRequestId",
                table: "Requests",
                column: "ClientRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Responses_RequestId",
                table: "Responses",
                column: "RequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Responses_TrainerId",
                table: "Responses",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_SignOutsFromTraining_ApplicationId",
                table: "SignOutsFromTraining",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_SignOutsFromTraining_ClientId",
                table: "SignOutsFromTraining",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_SignUpsForTraining_ApplicationId",
                table: "SignUpsForTraining",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_SignUpsForTraining_ClientId",
                table: "SignUpsForTraining",
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

            migrationBuilder.CreateIndex(
                name: "IX_TrainerTrainingSignOuts_TrainerId",
                table: "TrainerTrainingSignOuts",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerTrainingSignUps_TrainerId",
                table: "TrainerTrainingSignUps",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_RequestId",
                table: "Training",
                column: "RequestId",
                unique: true,
                filter: "[RequestId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Training_SignUpId",
                table: "Training",
                column: "SignUpId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_TrainerId",
                table: "Training",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_TrainerTrainingSignOutId",
                table: "Training",
                column: "TrainerTrainingSignOutId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Training_TrainerTrainingSignUpId",
                table: "Training",
                column: "TrainerTrainingSignUpId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Training_GroupTrainingId",
                table: "Applications",
                column: "GroupTrainingId",
                principalTable: "Training",
                principalColumn: "TrainingId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Persons_TrainerId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientRequests_Persons_ClientId",
                table: "ClientRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_SignUpsForTraining_Persons_ClientId",
                table: "SignUpsForTraining");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerTrainingSignOuts_Persons_TrainerId",
                table: "TrainerTrainingSignOuts");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerTrainingSignUps_Persons_TrainerId",
                table: "TrainerTrainingSignUps");

            migrationBuilder.DropForeignKey(
                name: "FK_Training_Persons_TrainerId",
                table: "Training");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Training_GroupTrainingId",
                table: "Applications");

            migrationBuilder.DropTable(
                name: "ClientGroupTokens");

            migrationBuilder.DropTable(
                name: "ClientPersonalTokens");

            migrationBuilder.DropTable(
                name: "GTokenGTraining");

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
                name: "PTokenPTraining");

            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "SignOutsFromTraining");

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

            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "SignUpsForTraining");

            migrationBuilder.DropTable(
                name: "TrainerTrainingSignOuts");

            migrationBuilder.DropTable(
                name: "TrainerTrainingSignUps");

            migrationBuilder.DropTable(
                name: "ClientRequests");

            migrationBuilder.DropTable(
                name: "Applications");
        }
    }
}
