using Group_14.BusinessLayer.Interfaces;
using Group_14.DataAccessLayer;
using Group_14.MovieReview.CoreLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Group_14.BusinessLayer.Services
{
    public class MovieService : IMovieService
    {
        private readonly AppDbContext _context;

        public MovieService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task<Movie> AddMovieAsync(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie> UpdateMovieAsync(Movie movie)
        {
            var existingMovie = await _context.Movies.FindAsync(movie.Id);
            if (existingMovie == null)
            {
                return null; // Không tìm thấy phim, trả về null
            }

            // Cập nhật thông tin phim
            existingMovie.Title = movie.Title;
            existingMovie.Genre = movie.Genre;
            existingMovie.ReleaseDate = movie.ReleaseDate;
            existingMovie.Description = movie.Description;

            await _context.SaveChangesAsync();
            return existingMovie;
        }


        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) return false;

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
