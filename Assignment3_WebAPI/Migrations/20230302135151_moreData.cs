using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment3_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class moreData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 4,
                column: "FullName",
                value: "James Rhodes");

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Alias", "FullName", "Picture" },
                values: new object[,]
                {
                    { 5, "Jabba the Hut", "Jabba Desilijic Tiure", "https://m.media-amazon.com/images/M/MV5BMTczNTI2ODUwOF5BMl5BanBnXkFtZTcwMTU0NTIzMw@@._V1_FMjpg_UX1000_.jpg" },
                    { 6, "Ben", "Obiwan Kenobi", "https://m.media-amazon.com/images/M/MV5BYTRhNjcwNWQtMGJmMi00NmQyLWE2YzItODVmMTdjNWI0ZDA2XkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_.jpg" },
                    { 7, "The Hulk", "Bruce Banner", "https://m.media-amazon.com/images/M/MV5BYTRhNjcwNWQtMGJmMi00NmQyLWE2YzItODVmMTdjNWI0ZDA2XkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_.jpg" },
                    { 8, "Captain America", "Steve Roger", "https://m.media-amazon.com/images/M/MV5BYTRhNjcwNWQtMGJmMi00NmQyLWE2YzItODVmMTdjNWI0ZDA2XkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_.jpg" }
                });

            migrationBuilder.InsertData(
                table: "MovieCharacter",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "FranchiseId", "Genre", "Picture", "Title", "Trailer" },
                values: new object[,]
                {
                    { 5, "George Lucas", 3, "Sci-fi", "https://m.media-amazon.com/images/M/MV5BYTRhNjcwNWQtMGJmMi00NmQyLWE2YzItODVmMTdjNWI0ZDA2XkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_.jpg", "Star Wars Episode VI", "https://www.youtube.com/watch?v=RlT3Xg0Iq_g" },
                    { 6, "George Lucas", 3, "Sci-fi", "https://m.media-amazon.com/images/M/MV5BYTRhNjcwNWQtMGJmMi00NmQyLWE2YzItODVmMTdjNWI0ZDA2XkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_.jpg", "Star Wars: Episode II", "https://www.youtube.com/watch?v=RlT3Xg0Iq_g" },
                    { 7, "George Lucas", 3, "Sci-fi", "https://m.media-amazon.com/images/M/MV5BYTRhNjcwNWQtMGJmMi00NmQyLWE2YzItODVmMTdjNWI0ZDA2XkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_.jpg", "Star Wars: Episode III", "https://www.youtube.com/watch?v=RlT3Xg0Iq_g" },
                    { 8, "Stan Lee", 1, "Action", "https://m.media-amazon.com/images/M/MV5BMTczNTI2ODUwOF5BMl5BanBnXkFtZTcwMTU0NTIzMw@@._V1_FMjpg_UX1000_.jpg", "The Incredible Hulk", "https://www.youtube.com/watch?v=RsCSvPIcIpw" },
                    { 9, "Stan Lee", 1, "Action", "https://m.media-amazon.com/images/M/MV5BMTczNTI2ODUwOF5BMl5BanBnXkFtZTcwMTU0NTIzMw@@._V1_FMjpg_UX1000_.jpg", "Avengers", "https://www.youtube.com/watch?v=RsCSvPIcIpw" }
                });

            migrationBuilder.InsertData(
                table: "MovieCharacter",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[,]
                {
                    { 6, 3 },
                    { 3, 5 },
                    { 5, 5 },
                    { 3, 6 },
                    { 6, 6 },
                    { 3, 7 },
                    { 6, 7 },
                    { 7, 8 },
                    { 1, 9 },
                    { 7, 9 },
                    { 8, 9 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieCharacter",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "MovieCharacter",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "MovieCharacter",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "MovieCharacter",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "MovieCharacter",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "MovieCharacter",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "MovieCharacter",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "MovieCharacter",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 6, 7 });

            migrationBuilder.DeleteData(
                table: "MovieCharacter",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "MovieCharacter",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "MovieCharacter",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "MovieCharacter",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 4,
                column: "FullName",
                value: "Rodney As");
        }
    }
}
