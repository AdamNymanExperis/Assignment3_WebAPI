﻿// <auto-generated />
using Assignment3_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment3_WebAPI.Migrations
{
    [DbContext(typeof(MovieDbContext))]
    partial class MovieDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Assignment3_WebAPI.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alias")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Alias = "Iron Man",
                            FullName = "Tony Stark",
                            Picture = "https://m.media-amazon.com/images/M/MV5BMTczNTI2ODUwOF5BMl5BanBnXkFtZTcwMTU0NTIzMw@@._V1_FMjpg_UX1000_.jpg"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "Jake Sully",
                            Picture = "https://lumiere-a.akamaihd.net/v1/images/image_88e83585.jpeg?region=0,0,540,810"
                        },
                        new
                        {
                            Id = 3,
                            Alias = "Darth Vader",
                            FullName = "Anakin Skywalker",
                            Picture = "https://m.media-amazon.com/images/M/MV5BYTRhNjcwNWQtMGJmMi00NmQyLWE2YzItODVmMTdjNWI0ZDA2XkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_.jpg"
                        },
                        new
                        {
                            Id = 4,
                            Alias = "War Machine",
                            FullName = "Rodney As",
                            Picture = "https://m.media-amazon.com/images/M/MV5BMTczNTI2ODUwOF5BMl5BanBnXkFtZTcwMTU0NTIzMw@@._V1_FMjpg_UX1000_.jpg"
                        });
                });

            modelBuilder.Entity("Assignment3_WebAPI.Models.Franchise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Franchises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Marvel cinematic universe",
                            Name = "Marvel"
                        },
                        new
                        {
                            Id = 2,
                            Description = "the Avatar movies",
                            Name = "Avatar"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Star wars movies",
                            Name = "Star Wars"
                        });
                });

            modelBuilder.Entity("Assignment3_WebAPI.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FranchiseId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Trailer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FranchiseId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Director = "Stan Lee",
                            FranchiseId = 1,
                            Genre = "Action",
                            Picture = "https://m.media-amazon.com/images/M/MV5BMTczNTI2ODUwOF5BMl5BanBnXkFtZTcwMTU0NTIzMw@@._V1_FMjpg_UX1000_.jpg",
                            Title = "Iron Man",
                            Trailer = "https://www.youtube.com/watch?v=RsCSvPIcIpw"
                        },
                        new
                        {
                            Id = 2,
                            Director = "James Cameron",
                            FranchiseId = 2,
                            Genre = "Sci-fi",
                            Picture = "https://lumiere-a.akamaihd.net/v1/images/image_88e83585.jpeg?region=0,0,540,810",
                            Title = "Avatar",
                            Trailer = "https://www.youtube.com/watch?v=nvAf39wCTaY"
                        },
                        new
                        {
                            Id = 3,
                            Director = "George Lucas",
                            FranchiseId = 3,
                            Genre = "Sci-fi",
                            Picture = "https://m.media-amazon.com/images/M/MV5BYTRhNjcwNWQtMGJmMi00NmQyLWE2YzItODVmMTdjNWI0ZDA2XkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_.jpg",
                            Title = "Star Wars: Episode I",
                            Trailer = "https://www.youtube.com/watch?v=RlT3Xg0Iq_g"
                        },
                        new
                        {
                            Id = 4,
                            Director = "Stan Lee",
                            FranchiseId = 1,
                            Genre = "Action",
                            Picture = "https://m.media-amazon.com/images/M/MV5BMTczNTI2ODUwOF5BMl5BanBnXkFtZTcwMTU0NTIzMw@@._V1_FMjpg_UX1000_.jpg",
                            Title = "Iron Man 2",
                            Trailer = "https://www.youtube.com/watch?v=RsCSvPIcIpw"
                        });
                });

            modelBuilder.Entity("MovieCharacter", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "CharacterId");

                    b.HasIndex("CharacterId");

                    b.ToTable("MovieCharacter");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            CharacterId = 1
                        },
                        new
                        {
                            MovieId = 2,
                            CharacterId = 2
                        },
                        new
                        {
                            MovieId = 3,
                            CharacterId = 3
                        },
                        new
                        {
                            MovieId = 4,
                            CharacterId = 4
                        });
                });

            modelBuilder.Entity("Assignment3_WebAPI.Models.Movie", b =>
                {
                    b.HasOne("Assignment3_WebAPI.Models.Franchise", "Franchise")
                        .WithMany("Movies")
                        .HasForeignKey("FranchiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Franchise");
                });

            modelBuilder.Entity("MovieCharacter", b =>
                {
                    b.HasOne("Assignment3_WebAPI.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment3_WebAPI.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Assignment3_WebAPI.Models.Franchise", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
