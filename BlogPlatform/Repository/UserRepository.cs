using BlogPlatform.Interfaces;
using BlogPlatform.Models;
using BlogPlatform.Context;
using BlogPlatform.Exceptions;
using BlogPlatform.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatform.Repository
{
    public class UserRepository : IRepository <User>
    {
        private readonly BlogPlatformContext _context;

        public UserRepository(BlogPlatformContext context  )
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(int userId )
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new NotFoundException($"User with ID {userId} not found.");
            }
            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (DatabaseUpdateException ex)
            {
                throw new DatabaseUpdateException("An error occurred while adding the user.", ex);
            }


        }

        public async Task UpdateAsync(User user)
        {
            var existingUser = await GetByIdAsync(user.userId);
            if (existingUser == null)
            {
                throw new NotFoundException($"User with ID {user.userId} not found.");
            }

            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DatabaseUpdateException("An error occurred while updating the user.", ex);
            }
        }

        public async Task DeleteAsync(int userId)
        {
            var user = await GetByIdAsync(userId);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }




    }
}
