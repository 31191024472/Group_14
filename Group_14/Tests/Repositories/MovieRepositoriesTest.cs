using Xunit;
using Moq;
using Group_14.DataAccessLayer.Repositories;
using Group_14.CoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Group_14.Tests.Repositories
{
    public class MovieRepositoryTests
    {
        private readonly Mock<IMovieRepository> _repositoryMock;

        public MovieRepositoryTests()
        {
            _repositoryMock = new Mock<IMovieRepository>();
        }

        [Fact]
        public async Task GetMoviesByTagAsync_ShouldReturnListOfMovies()
        {
            // Arrange
            var movies = new List<MovieSeries> { new MovieSeries { Title = "Avatar", Genre = "Sci-Fi" } };
            _repositoryMock.Setup(repo => repo.GetMoviesByTagAsync("Sci-Fi")).ReturnsAsync(movies);

            // Act
            var result = await _repositoryMock.Object.GetMoviesByTagAsync("Sci-Fi");

            // Assert
            Assert.Equal(movies, result);
        }
    }
}
