using Group_14.CoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Group_14.CoreLayer.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<MovieSeries>> GetAllMoviesAsync();
        Task<IEnumerable<MovieSeries>> GetTopRatedMoviesWithSpAsync(int topCount);
    }
}
