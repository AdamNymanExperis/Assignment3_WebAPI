using Assignment3_WebAPI.Exceptions;
using Assignment3_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment3_WebAPI.Services
{
    public class FranchiseService : IFranchiseService
    {
        private readonly MovieDbContext _context;

        public FranchiseService(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetMoviesInFranchise(int id)
        {
            var franchise = await _context.Franchises.Include(x => x.Movies).FirstOrDefaultAsync(x => x.Id == id);

            if (franchise == null)
            {
                throw new FranchiseNotFoundException(id);
            }

            return franchise.Movies;
        }

        public async Task<IEnumerable<Character>> GetCharactersInFranchise(int id)
        {
            var franchise = await _context.Franchises.Include(x => x.Movies).FirstOrDefaultAsync(x => x.Id == id);

            if (franchise == null)
            {
                throw new FranchiseNotFoundException(id);
            }

            var allCharactersInFranchise = new List<Character>();

            foreach (Movie movie in franchise.Movies) // remove duplicates?? 
            {
                var foundMovie = await _context.Movies.Include(x => x.Characters).FirstOrDefaultAsync(x => x.Id == movie.Id);
                
                if (foundMovie == null)
                {
                    throw new MovieNotFoundException(id);
                }
                
                allCharactersInFranchise.AddRange(foundMovie.Characters);
            }

            return allCharactersInFranchise.Distinct();
        }



        public async Task<Franchise> AddFranchise(Franchise franchise)
        {
            _context.Franchises.Add(franchise);
            await _context.SaveChangesAsync();

            return franchise;
        }

        public async Task DeleteFranchise(int id)
        {
            var franchise = await _context.Franchises.FindAsync(id);
            if (franchise == null)
            {
                throw new FranchiseNotFoundException(id);
            }

            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Franchise>> getAllFranchises()
        {
            return await _context.Franchises.Include(x => x.Movies).ToListAsync();
        }

        public async Task<Franchise> getFranchiseById(int id)
        {
            var franchise = await _context.Franchises.Include(x => x.Movies).FirstOrDefaultAsync(x => x.Id == id);

            if (franchise == null)
            {
                throw new FranchiseNotFoundException(id);
            }

            return franchise;
        }

        public async Task<Franchise> UpdateFranchise(Franchise franchise)
        {
            var foundFranchise = await _context.Franchises.AnyAsync(x => x.Id == franchise.Id);
            if (!foundFranchise)
            {
                throw new FranchiseNotFoundException(franchise.Id);
            }
            _context.Entry(franchise).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return franchise;
        }
    }
}
