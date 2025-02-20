using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group_14.API.Controllers;
using Group_14.CoreLayer.Entities;
using Group_14.DataAccessLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Group_14.Tests.Controllers
{
    public class MovieControllerTests
    {
        private readonly ApplicationDbContext _context;
        private readonly MoviesController _controller;

        public MovieControllerTests()
        {
            // Sử dụng InMemory Database để tạo database giả lập
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationDbContext(options);
            _controller = new MoviesController(_context);

            // Seed dữ liệu giả lập
            SeedDatabase();
        }

        private void SeedDatabase()
        {
            _context.MoviesSeries.AddRange(new List<MovieSeries>
            {
                new MovieSeries { MovieSeriesId = 1, Title = "Inception", Genre = "Sci-Fi" },
                new MovieSeries { MovieSeriesId = 2, Title = "The Matrix", Genre = "Action" }
            });

            _context.SaveChanges();
        }

        [Fact]
        public async Task GetMoviesByTag_ReturnsOk_WithMoviesList()
        {
            // Act
            var result = await _controller.GetMoviesByTag("Sci-Fi");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var movies = Assert.IsType<List<MovieSeries>>(okResult.Value);
            Assert.Single(movies);
            Assert.Equal("Inception", movies[0].Title);
        }

        [Fact]
        public async Task GetTopRatedMovies_ReturnsOk_WithMoviesList()
        {
            // Act
            var result = await _controller.GetTopRatedMovies(5);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var movies = Assert.IsType<List<MovieSeries>>(okResult.Value);
            Assert.NotEmpty(movies);
        }
    }
}
