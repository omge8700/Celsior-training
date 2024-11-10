using BlogPlatform.Interfaces;
using BlogPlatform.Models;
using BlogPlatform.Context;
using BlogPlatform.Exceptions;
using BlogPlatform.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatform.Repository
{
    public class UserRepository : IRepository<string, User>
    {
        private readonly  BlogPlatformContext _context;

        public UserRepository(BlogPlatformContext context)
        {
            _context = context;
        }
        public async Task<User> Add(User entity)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.email == entity.email );
                if (user == null)
                {
                    await _context.Users.AddAsync(entity);
                    await _context.SaveChangesAsync();
                    return entity;
                }
                else
                {
                    throw new InvalidOperationException("User already Exist.... Please LogIn");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"User Add Failed....{ex.Message}");
            }
        }

        public async Task<User> Delete(string key)
        {
            var deletedUser = await Get(key);
            if (deletedUser != null)
            {
                _context.Users.Remove(deletedUser);
                await _context.SaveChangesAsync();
                return deletedUser;
            }
            throw new Exception("Delete Failed");
        }

        public async Task<User> Get(string key)
        {
            var user = _context.Users.FirstOrDefault(x => x.email == key);
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = _context.Users.ToList();
            if (users.Any())
            {
                return users;
            }
            throw new Exception("Users Collection Empty");
        }

        public async Task<User> Update(User entity, string key)
        {
            var updatedUser = await Get(key);
            if (updatedUser != null)
            {
                updatedUser.email = entity.email;
                updatedUser.username = entity.username;
                updatedUser.password = entity.password;

                await _context.SaveChangesAsync();
                return updatedUser;
            }
            throw new Exception("Update Failed");
        }
    }
}
