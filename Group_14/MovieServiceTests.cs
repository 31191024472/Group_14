using Group_14.BusinessLayer.Interfaces;
using Group_14.MovieReview.CoreLayer.Entities;
using Moq;
using Xunit;

namespace Group_14
{
    public class MovieServiceTests
    {
        private readonly Mock<IMovieService> _mockMovieService;
        private readonly Movie _testMovie = new Movie { Id = 1, Title = "Test Movie", Genre = "Action" };

        public MovieServiceTests()
        {
            _mockMovieService = new Mock<IMovieService>();
        }

        [Fact]
        public async Task GetAllMoviesAsync_ReturnsMovies()
        {
            _mockMovieService.Setup(m => m.GetAllMoviesAsync()).ReturnsAsync(new List<Movie> { _testMovie });

            var movies = await _mockMovieService.Object.GetAllMoviesAsync();

            Assert.NotEmpty(movies);
        }

        [Fact]
        public async Task AddMovieAsync_ReturnsCreatedMovie()
        {
            _mockMovieService.Setup(m => m.AddMovieAsync(_testMovie)).ReturnsAsync(_testMovie);

            var movie = await _mockMovieService.Object.AddMovieAsync(_testMovie);

            Assert.Equal(_testMovie.Title, movie.Title);
        }
    }
}
