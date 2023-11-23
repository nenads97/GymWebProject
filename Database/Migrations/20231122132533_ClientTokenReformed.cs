using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class ClientTokenReformed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientGroupTokens_Persons_ClientId",
                table: "ClientGroupTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientGroupTokens_Tokens_GroupTokenId",
                table: "ClientGroupTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientPersonalTokens_Persons_ClientId",
                table: "ClientPersonalTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientPersonalTokens_Tokens_PersonalTokenId",
                table: "ClientPersonalTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Tokens_ClientPersonalTokens_ClientPersonalTokenId",
                table: "Tokens");

            migrationBuilder.DropIndex(
                name: "IX_ClientGroupTokens_GroupTokenId",
                table: "ClientGroupTokens");

            migrationBuilder.RenameColumn(
                name: "ClientPersonalTokenId",
                table: "Tokens",
                newName: "GroupToken_ClientId");

            migrationBuilder.RenameColumn(
                name: "ClientGroupTokenId",
                table: "Tokens",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Tokens_ClientPersonalTokenId",
                table: "Tokens",
                newName: "IX_Tokens_GroupToken_ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_ClientId",
                table: "Tokens",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientGroupTokens_GroupTokenId",
                table: "ClientGroupTokens",
                column: "GroupTokenId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientGroupTokens_Persons_ClientId",
                table: "ClientGroupTokens",
                column: "ClientId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientGroupTokens_Tokens_GroupTokenId",
                table: "ClientGroupTokens",
                column: "GroupTokenId",
                principalTable: "Tokens",
                principalColumn: "TokenId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientPersonalTokens_Persons_ClientId",
                table: "ClientPersonalTokens",
                column: "ClientId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientPersonalTokens_Tokens_PersonalTokenId",
                table: "ClientPersonalTokens",
                column: "PersonalTokenId",
                principalTable: "Tokens",
                principalColumn: "TokenId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tokens_Persons_ClientId",
                table: "Tokens",
                column: "ClientId",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tokens_Persons_GroupToken_ClientId",
                table: "Tokens",
                column: "GroupToken_ClientId",
                principalTable: "Persons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientGroupTokens_Persons_ClientId",
                table: "ClientGroupTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientGroupTokens_Tokens_GroupTokenId",
                table: "ClientGroupTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientPersonalTokens_Persons_ClientId",
                table: "ClientPersonalTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientPersonalTokens_Tokens_PersonalTokenId",
                table: "ClientPersonalTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Tokens_Persons_ClientId",
                table: "Tokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Tokens_Persons_GroupToken_ClientId",
                table: "Tokens");

            migrationBuilder.DropIndex(
                name: "IX_Tokens_ClientId",
                table: "Tokens");

            migrationBuilder.DropIndex(
                name: "IX_ClientGroupTokens_GroupTokenId",
                table: "ClientGroupTokens");

            migrationBuilder.RenameColumn(
                name: "GroupToken_ClientId",
                table: "Tokens",
                newName: "ClientPersonalTokenId");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Tokens",
                newName: "ClientGroupTokenId");

            migrationBuilder.RenameIndex(
                name: "IX_Tokens_GroupToken_ClientId",
                table: "Tokens",
                newName: "IX_Tokens_ClientPersonalTokenId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientGroupTokens_GroupTokenId",
                table: "ClientGroupTokens",
                column: "GroupTokenId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientGroupTokens_Persons_ClientId",
                table: "ClientGroupTokens",
                column: "ClientId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientGroupTokens_Tokens_GroupTokenId",
                table: "ClientGroupTokens",
                column: "GroupTokenId",
                principalTable: "Tokens",
                principalColumn: "TokenId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientPersonalTokens_Persons_ClientId",
                table: "ClientPersonalTokens",
                column: "ClientId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientPersonalTokens_Tokens_PersonalTokenId",
                table: "ClientPersonalTokens",
                column: "PersonalTokenId",
                principalTable: "Tokens",
                principalColumn: "TokenId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tokens_ClientPersonalTokens_ClientPersonalTokenId",
                table: "Tokens",
                column: "ClientPersonalTokenId",
                principalTable: "ClientPersonalTokens",
                principalColumn: "ClientPersonalTokenId");
        }
    }
}
