using BlogPlatform.Context;
using BlogPlatform.Exceptions;
using BlogPlatform.Interfaces;
using BlogPlatform.Models;
using BlogPlatform.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatform.Repository
{
    public class BloggerRepository : IRepository<Blogger>

    {
        private readonly BlogPlatformContext _context;

        public BloggerRepository(BlogPlatformContext context)
        {
            _context = context;
        }

        public async Task<Blogger> GetByIdAsync(int bloggerId)
        {
            var blogger = await _context.Blogs.FindAsync(bloggerId);
            if (blogger == null)
            {
                throw new NotFoundException($"Blogger with ID {bloggerId} not found.");
            }
            return blogger;
        }

        public async Task<IEnumerable<Blogger>> GetAllAsync()
        {
            return await _context.Blogs.ToListAsync();
        }

        public async Task AddAsync(Blogger blogger)
        {
            try
            {
                await _context.Blogs.AddAsync(blogger);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DatabaseUpdateException("An error occurred while adding the blogger.", ex);
            }
        }

        public async Task UpdateAsync(BlogPostDTO blogger)
        {
            var existingBlogger = await GetByIdAsync(blogger.PostId);
            if (existingBlogger == null)
            {
                throw new NotFoundException($"Blogger with ID {blogger.PostId} not found.");
            }

            try
            {
                _context.Blogs.Update(blogger);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DatabaseUpdateException("An error occurred while updating the blogger.", ex);
            }
        }

        public async Task DeleteAsync(int bloggerId)
        {
            var blogger = await GetByIdAsync(bloggerId);
            _context.Blogs.Remove(blogger);
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(Blogger entity)
        {
            throw new NotImplementedException();
        }
    }

}

