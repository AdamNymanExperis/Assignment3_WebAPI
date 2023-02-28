using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment3_WebAPI.Models;
using Assignment3_WebAPI.Models.Dtos.FranchiseDtos;
using AutoMapper;
using Assignment3_WebAPI.Services;
using Assignment3_WebAPI.Models.Dtos;
using Assignment3_WebAPI.Exceptions;
using Assignment3_WebAPI.Models.Dtos.MovieDtos;
using Assignment3_WebAPI.Models.Dtos.CharacterDtos;

namespace Assignment3_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FranchiseController : ControllerBase
    {
        private readonly IFranchiseService _franchiseService;
        private readonly IMapper _mapper;

        public FranchiseController(IFranchiseService franchiseService, IMapper mapper)
        {
            _franchiseService = franchiseService;
            _mapper = mapper;
        }

        [HttpGet("{id}/movies")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesInFranchise(int id)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<GetMovieDto>>(await _franchiseService.GetMoviesInFranchise(id)));
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        [HttpGet("{id}/characters")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetCharactersInFranchise(int id)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<GetCharacterDto>>(await _franchiseService.GetCharactersInFranchise(id)));
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        // GET: api/Franchises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetFranchiseDto>>> GetFranchises()
        {
            return Ok(_mapper.Map<IEnumerable<GetFranchiseDto>>(await _franchiseService.getAllFranchises()));
        }

        // GET: api/Franchises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetFranchiseDto>> GetFranchise(int id)
        {
            try
            {
                return Ok(_mapper.Map<GetFranchiseDto>(await _franchiseService.getFranchiseById(id)));
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        // PUT: api/Franchises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, PutFranchiseDto putFranchiseDto)
        {
            if (id != putFranchiseDto.Id)
            {
                return BadRequest();
            }

            try
            {
                Franchise domainfranchise = _mapper.Map<Franchise>(putFranchiseDto);
                await _franchiseService.UpdateFranchise(domainfranchise);
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }

        // POST: api/Franchises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Franchise>> PostFranchise(AddFranchiseDto addFranchiseDto)
        {
            var franchise = _mapper.Map<Franchise>(addFranchiseDto);
            await _franchiseService.AddFranchise(franchise);
            return CreatedAtAction(nameof(GetFranchise), new { id = franchise.Id }, franchise);
        }

        // DELETE: api/Franchises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            try
            {
                await _franchiseService.DeleteFranchise(id);
            }
            catch (FranchiseNotFoundException ex)
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

