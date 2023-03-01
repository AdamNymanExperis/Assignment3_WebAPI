﻿using System;
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

        /// <summary>
        /// Controller for GET characters in database.
        /// </summary>
        /// <returns>IEnumerable of GetCharacterDTO</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCharacterDto>>> GetCharacters()
        {
            return Ok(_mapper.Map<IEnumerable<GetCharacterDto>>(await _characterService.getAllCharacters()));
        }

        /// <summary>
        /// Controller for GET character by id.
        /// </summary>
        /// <param name="id">Id of character.</param>
        /// <returns>GetCharacterDTO</returns>
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

        /// <summary>
        /// Controller for POST character to the database.
        /// </summary>
        /// <param name="addCharacterDto">addCharacterDTO</param>
        /// <returns>The character that was added to the database.</returns>
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(AddCharacterDto addCharacterDto)
        {
            var character = _mapper.Map<Character>(addCharacterDto);
            await _characterService.AddCharacter(character);
            return CreatedAtAction(nameof(GetCharacter), new { id = character.Id }, character);
        }


        /// <summary>
        /// Controller for DELETE character from database. 
        /// </summary>
        /// <param name="id">Id of character</param>
        /// <returns>IActionresult for HTTP status code</returns>
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


        /// <summary>
        /// Controller for PUT character in databse.
        /// </summary>
        /// <param name="id">Id of character to be updated.</param>
        /// <param name="dtoCharacter">dtoCharacter with data for character.</param>
        /// <returns>IActionresult for HTTP status code</returns>
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
