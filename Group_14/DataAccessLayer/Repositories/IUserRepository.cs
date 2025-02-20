using System.Collections.Generic;
using System.Threading.Tasks;
using Group_14.CoreLayer.Entities;

namespace Group_14.DataAccessLayer.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email);
    }
}
