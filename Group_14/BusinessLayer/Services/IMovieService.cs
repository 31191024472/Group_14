using System.Collections.Generic;
using System.Threading.Tasks;
using Group_14.CoreLayer.Entities;

namespace Group_14.BusinessLayer.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Review>> GetMovieReviewsAsync(int movieSeriesId);
        Task AddReviewAsync(int userId, int movieSeriesId, string reviewText);
        Task<IEnumerable<MovieSeries>> GetTopRatedMoviesAsync(int topCount);
        Task<IEnumerable<MovieSeries>> GetMoviesByTagAsync(string tagName);
    }
}
