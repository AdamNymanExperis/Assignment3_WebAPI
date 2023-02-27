using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment3_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewRow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MovieCharacter",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[] { 3, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieCharacter",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 3, 1 });
        }
    }
}
