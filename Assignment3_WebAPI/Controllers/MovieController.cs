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
using Assignment3_WebAPI.Models.Dtos;
using Assignment3_WebAPI.Exceptions;
using Assignment3_WebAPI.Models.Dtos.MovieDtos;
using Assignment3_WebAPI.Models.Dtos.CharacterDtos;
using System.Net.Mime;

namespace Assignment3_WebAPI.Controllers
{
    [Route("api/v1")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MovieController(IMovieService movieService , IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        

        /// <summary>
        /// Gets all movies in the database.
        /// </summary>
        /// <returns>IEnumerable of GetMovieDTO</returns>
        [HttpGet("movies")]
        public async Task<ActionResult<IEnumerable<GetMovieDto>>> GetMovies()
        {
            return Ok(_mapper.Map<IEnumerable<GetMovieDto>>(await _movieService.getAllMovies()));
        }

        /// <summary>
        /// Adds a movie to the database. 
        /// </summary>
        /// <param name="addMovieDto">addMovieDTO</param>
        /// <returns>IActionresult for HTTP status code</returns>
        [HttpPost("movie")]
        public async Task<ActionResult<Movie>> PostMovie(AddMovieDto addMovieDto)
        {
            var movie = _mapper.Map<Movie>(addMovieDto);
            await _movieService.AddMovie(movie);
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }

        /// <summary>
        /// Gets a movie by id.
        /// </summary>
        /// <param name="id">Id of movie</param>
        /// <returns>GetMovieDTO</returns>
        [HttpGet("movie/{id}")]
        public async Task<ActionResult<GetMovieDto>> GetMovie(int id)
        {
            try
            {
                return Ok(_mapper.Map<GetMovieDto>(await _movieService.getMovieById(id)));
            }
            catch (MovieNotFoundException ex) 
            {
                return NotFound(new ProblemDetails { 
                    Detail = ex.Message
                });
            }
            
        }

        /// <summary>
        /// Removes a movie from the database.
        /// </summary>
        /// <param name="id">Id of movie to delete</param>
        /// <returns>IActionresult for HTTP status code</returns>
        [HttpDelete("movie/{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            try
            {
                await _movieService.DeleteMovie(id);
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Updates a movie in the database.
        /// </summary>
        /// <param name="id">Id of movie to be updated.</param>
        /// <param name="dtoMovie">dtoMovie</param>
        /// <returns>IActionresult for HTTP status code</returns>
        [HttpPut("movie/{id}")]
        public async Task<IActionResult> PutMovie(int id, PutMovieDto dtoMovie)
        {
            if (id != dtoMovie.Id)
            {
                return BadRequest();
            }

            try
            {
                Movie domainMovie = _mapper.Map<Movie>(dtoMovie);
                await _movieService.UpdateMovie(domainMovie);
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }

 
        /// <summary>
        /// Gets all characters in a movie.
        /// </summary>
        /// <param name="id">Id of movie</param>
        /// <returns>IEnumerable of Movie</returns>
        [HttpGet("movie/{id}/characters")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetCharactersInMovie(int id)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<GetCharacterDto>>(await _movieService.GetCharactersInMovie(id)));
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        /// <summary>
        /// Update characters in a movie.
        /// </summary>
        /// <param name="characterIds">Array of character ids</param>
        /// <param name="movieId">Id of movie.</param>
        /// <returns>IActionresult for HTTP status code</returns>
        [HttpPut("movie/{id}/characters")]
        public async Task<IActionResult> PutCharactersInMovie(int[] characterIds, int movieId)
        {
            try
            {
                await _movieService.UpdateCharactersInMovie(characterIds, movieId);
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
