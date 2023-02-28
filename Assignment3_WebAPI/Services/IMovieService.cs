using Assignment3_WebAPI.Models;

namespace Assignment3_WebAPI.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Character>> GetCharactersInMovie(int id);
        Task<Movie> AddMovie(Movie movie);
        Task DeleteMovie(int id);
        Task<IEnumerable<Movie>> getAllMovies();
        Task<Movie> getMovieById(int id);
        Task<Movie> UpdateMovie(Movie movie);
    }
}
