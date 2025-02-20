using System.Collections.Generic;
using System.Threading.Tasks;
using Group_14.CoreLayer.Entities;

namespace Group_14.DataAccessLayer.Repositories
{
    public interface IMovieRepository : IGenericRepository<MovieSeries>
    {
        Task<IEnumerable<Review>> GetMovieReviewsAsync(int movieSeriesId);
        Task AddReviewAsync(int userId, int movieSeriesId, string reviewText);
        Task<IEnumerable<MovieSeries>> GetTopRatedMoviesAsync(int topCount);
        Task<IEnumerable<MovieSeries>> GetMoviesByTagAsync(string tagName);
    }
}
