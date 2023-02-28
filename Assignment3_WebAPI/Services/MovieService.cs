using Assignment3_WebAPI.Exceptions;
using Assignment3_WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment3_WebAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext _context;

        public MovieService(MovieDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> getAllMovies()
        {
            return await _context.Movies.Include(x => x.Characters).ToListAsync();
        }

        public async Task<Movie> getMovieById(int id)
        {
            var movie = await _context.Movies.Include(x => x.Characters).FirstOrDefaultAsync(x => x.Id == id);


            if (movie == null)
            {
                throw new MovieNotFoundException(id);
            }

            return movie;
        }

        public async Task<Movie> AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        public async Task DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                throw new MovieNotFoundException(id);
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> UpdateMovie(Movie movie)
        {
            var foundMovie = await _context.Movies.AnyAsync(x => x.Id == movie.Id);
            if (!foundMovie)
            {
                throw new MovieNotFoundException(movie.Id);
            }
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return movie;
        }
    }
}
