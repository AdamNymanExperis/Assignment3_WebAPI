using Assignment3_WebAPI.Models;

namespace Assignment3_WebAPI.Services
{
    public interface ICharacterService
    {
        Task<Character> AddCharacter(Character character);
        Task DeleteCharacter(int id);
        Task<IEnumerable<Character>> getAllCharacters();
        Task<Character> getCharacterById(int id);
        Task<Character> UpdateCharacter(Character character);
    }
}
