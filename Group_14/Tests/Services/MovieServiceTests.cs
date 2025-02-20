using Xunit;
using Moq;
using Group_14.BusinessLayer.Services;
using Group_14.CoreLayer.Entities;
using Group_14.DataAccessLayer.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Group_14.Tests.Services
{
    public class MovieServiceTests
    {
        private readonly Mock<IMovieRepository> _repositoryMock;
        private readonly MovieService _movieService;

        public MovieServiceTests()
        {
            _repositoryMock = new Mock<IMovieRepository>();
            _movieService = new MovieService(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetMoviesByTagAsync_ReturnsMovieList()
        {
            // Arrange
            var movies = new List<MovieSeries> { new MovieSeries { Title = "Dune", Genre = "Sci-Fi" } };
            _repositoryMock.Setup(repo => repo.GetMoviesByTagAsync("Sci-Fi")).ReturnsAsync(movies);

            // Act
            var result = await _movieService.GetMoviesByTagAsync("Sci-Fi");

            // Assert
            Assert.Equal(movies, result);
        }
    }
}
