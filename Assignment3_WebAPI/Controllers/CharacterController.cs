using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment3_WebAPI.Models;
using Assignment3_WebAPI.Services;
using AutoMapper;
using Assignment3_WebAPI.Exceptions;
using Assignment3_WebAPI.Models.Dtos;
using Assignment3_WebAPI.Models.Dtos.CharacterDtos;

namespace Assignment3_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly IMapper _mapper;

        public CharacterController(ICharacterService characterService, IMapper mapper)
        {
            _characterService = characterService;
            _mapper = mapper;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCharacterDto>>> GetCharacters()
        {
            return Ok(_mapper.Map<IEnumerable<GetCharacterDto>>(await _characterService.getAllCharacters()));
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCharacterDto>> GetCharacter(int id)
        {
            try
            {
                return Ok(_mapper.Map<GetCharacterDto>(await _characterService.getCharacterById(id)));
            }
            catch (CharacterNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

        }

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(AddCharacterDto addCharacterDto)
        {
            var character = _mapper.Map<Character>(addCharacterDto);
            await _characterService.AddCharacter(character);
            return CreatedAtAction(nameof(GetCharacter), new { id = character.Id }, character);
        }


        // DELETE: api/Character/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            try
            {
                await _characterService.DeleteCharacter(id);
            }
            catch (CharacterNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }


        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, PutCharacterDto dtoCharacter)
        {
            if (id != dtoCharacter.Id)
            {
                return BadRequest();
            }

            try
            {
                Character domainCharacter = _mapper.Map<Character>(dtoCharacter);
                await _characterService.UpdateCharacter(domainCharacter);
            }
            catch (CharacterNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }
    }
}
