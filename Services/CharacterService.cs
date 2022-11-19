using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using temp_api.Data;
using temp_api.DTOs;
using temp_api.Interfaces;
using temp_api.Models;

namespace temp_api.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper mapper;
        private readonly CharacterContext dbContext;

        public CharacterService(IMapper mapper, CharacterContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }
        public async Task<List<Character>> GetCharacters()
        {
            var query = await dbContext.Characters.ToListAsync();
            return query;
        }

        public async Task<Character> GetSingleCharacter(int id)
        {
            var query = await dbContext.Characters.Where(x => x.ID == id).FirstOrDefaultAsync();
            if (query is null)
            {
                return null;
            }
            return query;
        }
        public async Task<Character> AddCharacter(AddCharacterDTO newCharacter)
        {
            Character NewCharacter = mapper.Map<Character>(newCharacter);
            dbContext.Characters.Add(NewCharacter);
            await dbContext.SaveChangesAsync();
            return NewCharacter;
        }
        public async Task<Character> EditCharacter(Character editCharacter)
        {
            var query = await dbContext.Characters.Where(x => x.ID == editCharacter.ID).FirstOrDefaultAsync();
            if (query is null)
            {
                return null;
            }
            query.Name = editCharacter.Name;
            query.Strength = editCharacter.Strength;
            query.Agility = editCharacter.Agility;
            query.Intelligence = editCharacter.Intelligence;
            dbContext.SaveChanges();

            return query;
        }

        public async Task<Character> DeleteCharacter(int id)
        {
            var query = await dbContext.Characters.Where(x => x.ID == id).FirstOrDefaultAsync();
            if (query is null)
            {
                return null;
            }
            dbContext.Characters.Remove(query);
            dbContext.SaveChanges();
            return query;
        }


    }
}
