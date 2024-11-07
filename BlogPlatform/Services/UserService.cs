using System.Collections.Generic;
using System.Threading.Tasks;
using BlogPlatform.Models;
using BlogPlatform.Interfaces;
using BlogPlatform.Exceptions;
using BlogPlatform.Repository;


namespace BlogPlatform.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;

            
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetByIdAsync(userId);

        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();

        }

        public async Task AddUserAsync(User user)
        {
            try
            {
                await _userRepository.AddAsync(user);
            }
            catch (DatabaseUpdateException ex)
            {
                throw new ServiceException("Failed to add user.", ex);
            }p
        }



    }
}
