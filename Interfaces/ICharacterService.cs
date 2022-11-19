using System;
using temp_api.DTOs;
using temp_api.Models;

namespace temp_api.Interfaces
{
    public interface ICharacterService
    {
        public Task<List<Character>> GetCharacters();
        public Task<Character> GetSingleCharacter(int id);
        public Task<Character> AddCharacter(AddCharacterDTO newCharacter);
        public Task<Character> EditCharacter(Character editCharacter);
        public Task<Character> DeleteCharacter(int id);
    }
}
