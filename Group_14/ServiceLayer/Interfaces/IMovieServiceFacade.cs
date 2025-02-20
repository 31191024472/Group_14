using Group_14.MovieReview.CoreLayer.Entities;

namespace Group_14.ServiceLayer.Interfaces
{
    public interface IMovieServiceFacade
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
        Task<Movie> GetMovieByIdAsync(int id);
        Task<Movie> AddMovieAsync(Movie movie);
        Task<Movie> UpdateMovieAsync(Movie movie);
        Task<bool> DeleteMovieAsync(int id);
    }
}
