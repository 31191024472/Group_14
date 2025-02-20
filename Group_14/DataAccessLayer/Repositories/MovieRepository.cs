using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Group_14.CoreLayer.Entities;

namespace Group_14.DataAccessLayer.Repositories
{
    public class MovieRepository : GenericRepository<MovieSeries>, IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Review>> GetMovieReviewsAsync(int movieSeriesId)
        {
            return await _context.Reviews
                .FromSqlRaw("EXEC GetMovieReviews @p0", movieSeriesId)
                .ToListAsync();
        }

        public async Task AddReviewAsync(int userId, int movieSeriesId, string reviewText)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC AddReview @p0, @p1, @p2",
                userId, movieSeriesId, reviewText
            );
        }

        public async Task<IEnumerable<MovieSeries>> GetTopRatedMoviesAsync(int topCount)
        {
            return await _context.MoviesSeries
                .FromSqlRaw("EXEC GetTopRatedMovies @p0", topCount)
                .ToListAsync();
        }

        public async Task<IEnumerable<MovieSeries>> GetMoviesByTagAsync(string tagName)
        {
            return await _context.MoviesSeries
                .FromSqlRaw("EXEC GetMoviesByTag @p0", tagName)
                .ToListAsync();
        }
    }
}
