using Microsoft.AspNetCore.Mvc;
using Group_14.CoreLayer.Entities;
using Group_14.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Group_14.API.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lấy danh sách phim
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieSeries>>> GetMovies()
        {
            return await _context.MoviesSeries.ToListAsync();
        }

        // Lấy danh sách phim theo tag
        [HttpGet("tag/{tagName}")]
        public async Task<ActionResult<IEnumerable<MovieSeries>>> GetMoviesByTag(string tagName)
        {
            return await _context.MoviesSeries
                .FromSqlRaw("EXEC GetMoviesByTag @p0", tagName)
                .ToListAsync();
        }

        // Lấy danh sách phim được đánh giá cao nhất
        [HttpGet("top-rated/{count}")]
        public async Task<ActionResult<IEnumerable<MovieSeries>>> GetTopRatedMovies(int count)
        {
            return await _context.MoviesSeries
                .FromSqlRaw("EXEC GetTopRatedMovies @p0", count)
                .ToListAsync();
        }
    }
}
