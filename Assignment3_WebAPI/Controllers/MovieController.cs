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

namespace Assignment3_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        //private readonly MovieDbContext _context;
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MovieController(IMovieService movieService , IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetMovieDto>>> GetMovies()
        {
            return Ok(_mapper.Map<IEnumerable<GetMovieDto>>(await _movieService.getAllMovies()));
        }
        
        // GET: api/Movies/5
        [HttpGet("{id}")]
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

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(AddMovieDto addMovieDto)
        {
            var movie = _mapper.Map<Movie>(addMovieDto);
            await _movieService.AddMovie(movie);
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }

        
        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
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

        
        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
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
    }
}
