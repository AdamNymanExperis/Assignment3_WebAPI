using Microsoft.EntityFrameworkCore;

namespace Assignment3_WebAPI.Models
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set;}
        public DbSet<Franchise> Franchises { get;set;}
        public DbSet<Character> Characters { get; set;}

        public MovieDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Movie>().HasData(
                    new Movie { Id = 1, Title = "Iron Man", Genre = "Action", Director = "Stan Lee", Picture = "https://m.media-amazon.com/images/M/MV5BMTczNTI2ODUwOF5BMl5BanBnXkFtZTcwMTU0NTIzMw@@._V1_FMjpg_UX1000_.jpg", Trailer = "https://www.youtube.com/watch?v=RsCSvPIcIpw", FranchiseId = 1 },
                    new Movie { Id = 2, Title = "Avatar", Genre = "Sci-fi", Director = "James Cameron", Picture = "https://lumiere-a.akamaihd.net/v1/images/image_88e83585.jpeg?region=0,0,540,810", Trailer = "https://www.youtube.com/watch?v=nvAf39wCTaY", FranchiseId = 2},
                    new Movie { Id = 3, Title = "Star Wars: Episode I", Genre = "Sci-fi", Director = "George Lucas", Picture = "https://m.media-amazon.com/images/M/MV5BYTRhNjcwNWQtMGJmMi00NmQyLWE2YzItODVmMTdjNWI0ZDA2XkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_.jpg", Trailer = "https://www.youtube.com/watch?v=RlT3Xg0Iq_g", FranchiseId = 3 },
                    new Movie { Id = 4, Title = "Iron Man 2", Genre = "Action", Director = "Stan Lee", Picture = "https://m.media-amazon.com/images/M/MV5BMTczNTI2ODUwOF5BMl5BanBnXkFtZTcwMTU0NTIzMw@@._V1_FMjpg_UX1000_.jpg", Trailer = "https://www.youtube.com/watch?v=RsCSvPIcIpw", FranchiseId = 1 },
                    new Movie { Id = 5, Title = "Star Wars Episode VI", Genre = "Action", Director = "Stan Lee", Picture = "https://m.media-amazon.com/images/M/MV5BMTczNTI2ODUwOF5BMl5BanBnXkFtZTcwMTU0NTIzMw@@._V1_FMjpg_UX1000_.jpg", Trailer = "https://www.youtube.com/watch?v=RsCSvPIcIpw", FranchiseId = 1 }

                );

            _ = modelBuilder.Entity<Character>().HasData(
                    new Character { Id = 1, FullName = "Tony Stark", Alias = "Iron Man", Picture = "https://m.media-amazon.com/images/M/MV5BMTczNTI2ODUwOF5BMl5BanBnXkFtZTcwMTU0NTIzMw@@._V1_FMjpg_UX1000_.jpg" },
                    new Character { Id = 2, FullName = "Jake Sully", Picture = "https://lumiere-a.akamaihd.net/v1/images/image_88e83585.jpeg?region=0,0,540,810" },
                    new Character { Id = 3, FullName = "Anakin Skywalker", Alias = "Darth Vader", Picture = "https://m.media-amazon.com/images/M/MV5BYTRhNjcwNWQtMGJmMi00NmQyLWE2YzItODVmMTdjNWI0ZDA2XkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_.jpg" },
                    new Character { Id = 4, FullName = "James Rhodes", Alias = "War Machine", Picture = "https://m.media-amazon.com/images/M/MV5BMTczNTI2ODUwOF5BMl5BanBnXkFtZTcwMTU0NTIzMw@@._V1_FMjpg_UX1000_.jpg" },
                    new Character { Id = 5, FullName = "Jabba The Hut", Alias = "Hutta", Picture = "https://m.media-amazon.com/images/M/MV5BMTczNTI2ODUwOF5BMl5BanBnXkFtZTcwMTU0NTIzMw@@._V1_FMjpg_UX1000_.jpg" }

                );
            modelBuilder.Entity<Franchise>().HasData(
                    new Franchise { Id = 1, Name = "Marvel", Description = "Marvel cinematic universe" },
                    new Franchise { Id = 2, Name = "Avatar", Description = "the Avatar movies" },
                    new Franchise { Id = 3, Name = "Star Wars", Description = "Star wars movies"}
                );

            modelBuilder.Entity<Movie>()
                .HasMany(movie => movie.Characters)
                .WithMany(character => character.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieCharacter",
                    r => r.HasOne<Character>().WithMany().HasForeignKey("CharacterId"),
                    l => l.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                    je =>
                    {
                        je.HasKey("MovieId", "CharacterId");
                        je.HasData(
                            new { MovieId = 1, CharacterId = 1 },
                            new { MovieId = 2, CharacterId = 2 },
                            new { MovieId = 3, CharacterId = 3 },
                            new { MovieId = 4, CharacterId = 4 },
                            new { MovieId = 4, CharacterId = 1 },
                            new { MovieId = 5, CharacterId = 5 },
                            new { MovieId = 5, CharacterId = 3 }




                        );
                    });
            
        }
    }
}
