using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddTokenData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tokens",
                columns: new[] { "TokenId", "Discriminator", "TokenType" },
                values: new object[,]
                {
                    { 1, "Token", 0 },
                    { 2, "Token", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tokens",
                keyColumn: "TokenId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tokens",
                keyColumn: "TokenId",
                keyValue: 2);
        }
    }
}
