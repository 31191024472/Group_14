using Moq;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Group_14.BusinessLayer.Services;
using Group_14.MovieReview.CoreLayer.Entities;
using Group_14.DataAccessLayer;
namespace Group_14.TestLayer
{
    public class MovieServiceTests
    {
        private readonly MovieService _movieService;
        private readonly Mock<AppDbContext> _mockDbContext;
        private readonly DbContextOptions<AppDbContext> _dbContextOptions;

        public MovieServiceTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            var context = new AppDbContext(_dbContextOptions);

            // Thêm dữ liệu test
            context.Movies.Add(new Movie { Id = 1, Title = "Inception", Genre = "Sci-Fi" });
            context.SaveChanges();

            _movieService = new MovieService(context);
        }

        [Fact]
        public async Task GetAllMoviesAsync_ReturnsMovies()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            Assert.NotEmpty(movies);
            Assert.Single(movies);
        }

        [Fact]
        public async Task AddMovieAsync_ReturnsCreatedMovie()
        {
            var newMovie = new Movie { Title = "Interstellar", Genre = "Sci-Fi" };
            var result = await _movieService.AddMovieAsync(newMovie);

            Assert.NotNull(result);
            Assert.Equal("Interstellar", result.Title);
        }

        [Fact]
        public async Task GetMovieByIdAsync_ReturnsCorrectMovie()
        {
            var movie = await _movieService.GetMovieByIdAsync(1);
            Assert.NotNull(movie);
            Assert.Equal("Inception", movie.Title);
        }

        [Fact]
        public async Task UpdateMovieAsync_UpdatesExistingMovie()
        {
            var movie = new Movie { Id = 1, Title = "Inception Updated", Genre = "Sci-Fi" };
            var updatedMovie = await _movieService.UpdateMovieAsync(movie);

            Assert.NotNull(updatedMovie);
            Assert.Equal("Inception Updated", updatedMovie.Title);
        }

        [Fact]
        public async Task DeleteMovieAsync_RemovesMovie()
        {
            var result = await _movieService.DeleteMovieAsync(1);
            Assert.True(result);
        }
    }
}
