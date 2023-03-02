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
using System.Net.Mime;

namespace Assignment3_WebAPI.Controllers
{
    [Route("api/v1/franchises")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class FranchiseController : ControllerBase
    {
        private readonly IFranchiseService _franchiseService;
        private readonly IMapper _mapper;

        public FranchiseController(IFranchiseService franchiseService, IMapper mapper)
        {
            _franchiseService = franchiseService;
            _mapper = mapper;
        }
       
        /// <summary>
        /// Gets all the franchises in the database.
        /// </summary>
        /// <returns>IEnumerable of GetFranchiseDto</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetFranchiseDto>>> GetFranchises()
        {
            return Ok(_mapper.Map<IEnumerable<GetFranchiseDto>>(await _franchiseService.getAllFranchises()));
        }

        /// <summary>
        /// Gets a franchise by id.
        /// </summary>
        /// <param name="id">The id of the franchise.</param>
        /// <returns>A GetFranchiseDto</returns>
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

        /// <summary>
        /// Updates a franchise in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="putFranchiseDto"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Adds a new franchise to the database.
        /// </summary>
        /// <param name="addFranchiseDto">DTO holding franchise data.</param>
        /// <returns>The Franchise that was posted.</returns>
        [HttpPost]
        public async Task<ActionResult<Franchise>> PostFranchise(AddFranchiseDto addFranchiseDto)
        {
            var franchise = _mapper.Map<Franchise>(addFranchiseDto);
            await _franchiseService.AddFranchise(franchise);
            return CreatedAtAction(nameof(GetFranchise), new { id = franchise.Id }, franchise);
        }

        /// <summary>
        /// Removes a franchise by id
        /// </summary>
        /// <param name="id">The id of the franchise to be removed from database.</param>
        /// <returns>IActionresult for HTTP status code</returns>
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

        /// <summary>
        /// Gets all the movies belonging to a franchise.
        /// </summary>
        /// <param name="id">The id of the franchise.</param>
        /// <returns></returns>
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
        /// <summary>
        /// Gets all the characters that are connected to a franchise.
        /// </summary>
        /// <param name="id">The id of the franchise.</param>
        /// <returns>IEnumerable of Movie</returns>
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

        /// <summary>
        /// Updates movies belonging to a franchise.
        /// </summary>
        /// <param name="movieIds">List of ids belonging to a franchise. </param>
        /// <param name="franchiseId">The id of the franchise to be updatded.</param>
        /// <returns>IActionresult for HTTP status code</returns>
        [HttpPut("{id}/movies")]
        public async Task<IActionResult> PutMoviesInFranchise(int[] movieIds, int franchiseId)
        {
            try
            {
                await _franchiseService.UpdateMoviesInFranchise(movieIds, franchiseId);
                return NoContent();
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(
                    new ProblemDetails()
                    {
                        Detail = ex.Message
                    }
                    );
            }
        }
    }
}

