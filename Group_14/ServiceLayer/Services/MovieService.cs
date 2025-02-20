using Group_14.BusinessLayer.Interfaces;
using Group_14.MovieReview.CoreLayer.Entities;
using Group_14.MovieReview.CoreLayer.Entities;
using Group_14.ServiceLayer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Group_14.ServiceLayer.Services
{
    public class MovieServiceFacade : IMovieServiceFacade
    {
        private readonly IMovieService _businessService; // Gọi đến BusinessLayer

        public MovieServiceFacade(IMovieService businessService)
        {
            _businessService = businessService;
        }

        public Task<IEnumerable<Movie>> GetAllMoviesAsync() => _businessService.GetAllMoviesAsync();
        public Task<Movie> GetMovieByIdAsync(int id) => _businessService.GetMovieByIdAsync(id);
        public Task<Movie> AddMovieAsync(Movie movie) => _businessService.AddMovieAsync(movie);
        public Task<Movie> UpdateMovieAsync(Movie movie) => _businessService.UpdateMovieAsync(movie);
        public Task<bool> DeleteMovieAsync(int id) => _businessService.DeleteMovieAsync(id);
    }
}
