using System.Collections.Generic;
using System.Threading.Tasks;
using Group_14.CoreLayer.Entities;
using Group_14.DataAccessLayer.Repositories;

namespace Group_14.BusinessLayer.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<Review>> GetMovieReviewsAsync(int movieSeriesId)
        {
            return await _movieRepository.GetMovieReviewsAsync(movieSeriesId);
        }

        public async Task AddReviewAsync(int userId, int movieSeriesId, string reviewText)
        {
            await _movieRepository.AddReviewAsync(userId, movieSeriesId, reviewText);
        }

        public async Task<IEnumerable<MovieSeries>> GetTopRatedMoviesAsync(int topCount)
        {
            return await _movieRepository.GetTopRatedMoviesAsync(topCount);
        }

        public async Task<IEnumerable<MovieSeries>> GetMoviesByTagAsync(string tagName)
        {
            return await _movieRepository.GetMoviesByTagAsync(tagName);
        }
    }
}
