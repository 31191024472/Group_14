using Group_14.MovieReview.CoreLayer.Entities;
using Group_14.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Group_14.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] Movie movie)
        {
            if (movie == null) return BadRequest();
            var createdMovie = await _movieService.AddMovieAsync(movie);
            return CreatedAtAction(nameof(GetMovieById), new { id = createdMovie.Id }, createdMovie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] Movie movie)
        {
            if (id != movie.Id) return BadRequest();
            var updatedMovie = await _movieService.UpdateMovieAsync(movie);
            return Ok(updatedMovie);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var result = await _movieService.DeleteMovieAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
