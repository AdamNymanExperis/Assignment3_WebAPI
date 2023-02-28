using Assignment3_WebAPI.Models;

namespace Assignment3_WebAPI.Services
{
    public interface IFranchiseService
    {
        Task<IEnumerable<Movie>> GetMoviesInFranchise(int id);

        Task<IEnumerable<Character>> GetCharactersInFranchise(int id);

        Task<Franchise> AddFranchise(Franchise franchise);
        Task DeleteFranchise(int id);
        Task<IEnumerable<Franchise>> getAllFranchises();
        Task<Franchise> getFranchiseById(int id);
        Task<Franchise> UpdateFranchise(Franchise franchise);

        Task UpdateMoviesInFranchise(int[] movieIds, int franchiseId);
    }
}
