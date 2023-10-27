using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageAdministrators_Persons_AdministratorId",
                table: "PackageAdministrators");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_PackageAdministrators_PackageAdministratorId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_PackageAdministratorId",
                table: "Packages");

            migrationBuilder.RenameColumn(
                name: "PackageAdministratorId",
                table: "Packages",
                newName: "AdministratorId");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_AdministratorId",
                table: "Packages",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageAdministrators_PackageId",
                table: "PackageAdministrators",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageAdministrators_Packages_PackageId",
                table: "PackageAdministrators",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "PackageId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PackageAdministrators_Persons_AdministratorId",
                table: "PackageAdministrators",
                column: "AdministratorId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Persons_AdministratorId",
                table: "Packages",
                column: "AdministratorId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageAdministrators_Packages_PackageId",
                table: "PackageAdministrators");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageAdministrators_Persons_AdministratorId",
                table: "PackageAdministrators");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Persons_AdministratorId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_AdministratorId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_PackageAdministrators_PackageId",
                table: "PackageAdministrators");

            migrationBuilder.RenameColumn(
                name: "AdministratorId",
                table: "Packages",
                newName: "PackageAdministratorId");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_PackageAdministratorId",
                table: "Packages",
                column: "PackageAdministratorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PackageAdministrators_Persons_AdministratorId",
                table: "PackageAdministrators",
                column: "AdministratorId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_PackageAdministrators_PackageAdministratorId",
                table: "Packages",
                column: "PackageAdministratorId",
                principalTable: "PackageAdministrators",
                principalColumn: "PackageAdministratorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
