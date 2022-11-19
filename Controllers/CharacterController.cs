using System;
using Microsoft.AspNetCore.Mvc;
using temp_api.DTOs;
using temp_api.Interfaces;
using temp_api.Models;

namespace temp_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService characterService;

        public CharacterController(ICharacterService characterService)
        {
            this.characterService = characterService;
        }

        [HttpGet]
        [Route("characters")]
        public async Task<ActionResult> GetCharacters()
        {
            var query = await characterService.GetCharacters();
            return Ok(query);
        }

        [HttpGet]
        [Route("character/{id}")]
        public async Task<ActionResult> GetSingleCharacter(int id)
        {
            var query = await characterService.GetSingleCharacter(id);
            if (query is null)
            {
                return NotFound("not found");
            }
            return Ok(query);
        }

        [HttpPost]
        [Route("addcharacter")]
        public async Task<ActionResult> AddCharacter(AddCharacterDTO newCharacter)
        {
            var query = await characterService.AddCharacter(newCharacter);
            return CreatedAtAction("GetSingleCharacter", new { ID = query.ID }, newCharacter);
        }

        [HttpPut]
        [Route("editcharacter")]
        public async Task<ActionResult> EditCharacter(Character editCharacter)
        {
            var query = await characterService.EditCharacter(editCharacter);
            if (query is null)
            {
                return NotFound("not found");
            }
            return Ok(query);
        }

        [HttpDelete]
        [Route("deletecharacter/{id}")]
        public async Task<ActionResult> DeleteCharacter(int id)
        {
            var query = await characterService.DeleteCharacter(id);
            if (query is null)
            {
                return NotFound("not found");
            }
            return Ok(query);
        }

    }
}
