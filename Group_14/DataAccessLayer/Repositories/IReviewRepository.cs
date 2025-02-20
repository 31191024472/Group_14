using System.Collections.Generic;
using System.Threading.Tasks;
using Group_14.CoreLayer.Entities;

namespace Group_14.DataAccessLayer.Repositories
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        Task<IEnumerable<Review>> GetReviewsByUserIdAsync(int userId);
    }
}
