using Microsoft.AspNetCore.Mvc;
using Group_14.CoreLayer.Entities;
using Group_14.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Group_14.API.Controllers
{
    [Route("api/movies/{movieSeriesId}/reviews")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lấy danh sách đánh giá của một phim
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetMovieReviews(int movieSeriesId)
        {
            return await _context.Reviews
                .FromSqlRaw("EXEC GetMovieReviews @p0", movieSeriesId)
                .ToListAsync();
        }

        // Thêm đánh giá mới
        [HttpPost]
        public async Task<IActionResult> AddReview(int movieSeriesId, [FromBody] Review review)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC AddReview @p0, @p1, @p2",
                review.UserId, movieSeriesId, review.ReviewText
            );

            return Ok(new { message = "Đánh giá đã được thêm thành công." });
        }
    }
}
