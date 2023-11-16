using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class MembershipUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_Persons_ClientId",
                table: "Memberships");

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_Persons_ClientId",
                table: "Memberships",
                column: "ClientId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_Persons_ClientId",
                table: "Memberships");

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_Persons_ClientId",
                table: "Memberships",
                column: "ClientId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
