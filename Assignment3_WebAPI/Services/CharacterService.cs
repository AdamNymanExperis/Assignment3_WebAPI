using Assignment3_WebAPI.Exceptions;
using Assignment3_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment3_WebAPI.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly MovieDbContext _context;
        public CharacterService(MovieDbContext context)
        {
            _context = context;
        }
        public async Task<Character> AddCharacter(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            return character;
        }

        public async Task DeleteCharacter(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                throw new CharacterNotFoundException(id);
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Character>> getAllCharacters()
        {
            return await _context.Characters.Include(x => x.Movies).ToListAsync();
        }

        public async Task<Character> getCharacterById(int id)
        {
            var character = await _context.Characters.Include(x => x.Movies).FirstOrDefaultAsync(x => x.Id == id);

            if (character == null)
            {
                throw new CharacterNotFoundException(id);
            }

            return character;
        }

        public async Task<Character> UpdateCharacter(Character character)
        {
            var foundCharacter = await _context.Characters.AnyAsync(x => x.Id == character.Id);
            if (!foundCharacter)
            {
                throw new CharacterNotFoundException(character.Id);
            }
            _context.Entry(character).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return character;
        }
    }
}
