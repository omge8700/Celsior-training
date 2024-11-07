using System.Collections.Generic;
using System.Threading.Tasks;
using BlogPlatform.Models;



namespace BlogPlatform.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int userid);
        Task<IEnumerable<User>> GetAllUsersAsync();

        Task AddUserAsync(User user);

        Task UpdateUserAsync(User user);

        Task DeleteUserAsync(int userid);

    }
}
