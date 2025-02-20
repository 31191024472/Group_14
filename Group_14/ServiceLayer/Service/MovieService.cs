using Group_14.MovieReview.CoreLayer.Entities;

namespace Group_14.ServiceLayer.Service
{
    public class MovieService:IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        // CRUD Methods
        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _movieRepository.GetAllMoviesAsync();
        }
        public async Task AddMovieAsync(Movie movie)
        {
            await _movieRepository.AddMovieAsync(movie);
        }
        // Stored Procedure Method
        public async Task<IEnumerable<Movie>>
       GetTopRatedMoviesWithSpAsync(int topCount)
        {
            return await
           _movieRepository.GetTopRatedMoviesWithSpAsync(topCount);
        }
    }
}
