using Microsoft.AspNetCore.Mvc;
using Group_14.CoreLayer.Entities;
using Group_14.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Group_14.API.Controllers
{
    [Route("api/ratings")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RatingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Thêm xếp hạng mới cho phim
        [HttpPost]
        public async Task<IActionResult> AddRating([FromBody] Rating rating)
        {
            await _context.Ratings.AddAsync(rating);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Xếp hạng đã được thêm thành công." });
        }
    }
}
