using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment3_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedMoreSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Alias", "FullName", "Picture" },
                values: new object[] { 4, "War Machine", "Rodney As", "https://m.media-amazon.com/images/M/MV5BMTczNTI2ODUwOF5BMl5BanBnXkFtZTcwMTU0NTIzMw@@._V1_FMjpg_UX1000_.jpg" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "FranchiseId", "Genre", "Picture", "Title", "Trailer" },
                values: new object[] { 4, "Stan Lee", 1, "Action", "https://m.media-amazon.com/images/M/MV5BMTczNTI2ODUwOF5BMl5BanBnXkFtZTcwMTU0NTIzMw@@._V1_FMjpg_UX1000_.jpg", "Iron Man 2", "https://www.youtube.com/watch?v=RsCSvPIcIpw" });

            migrationBuilder.InsertData(
                table: "MovieCharacter",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[] { 4, 4 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieCharacter",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
