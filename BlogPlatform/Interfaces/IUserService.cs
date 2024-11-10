using System.Collections.Generic;
using System.Threading.Tasks;
using BlogPlatform.Models;
using BlogPlatform.Models.DTOs;



namespace BlogPlatform.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int userid);
        //Task<IEnumerable<User>> GetAllUsersAsync();

        Task<LoginResponse> AddUserAsync(UserDTO user);

        Task<LoginResponse> LoginUser(LoginRequest loginUser);



        //Task DeleteUserAsync(int userid);

    }
}
