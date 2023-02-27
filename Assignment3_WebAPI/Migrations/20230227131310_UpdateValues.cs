using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment3_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieCharacter",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "MovieCharacter",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "MovieCharacter",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieCharacter",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "MovieCharacter",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "MovieCharacter",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 1 }
                });
        }
    }
}
