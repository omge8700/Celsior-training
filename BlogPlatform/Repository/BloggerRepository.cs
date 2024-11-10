using BlogPlatform.Context;
using BlogPlatform.Exceptions;
using BlogPlatform.Interfaces;
using BlogPlatform.Models;
using BlogPlatform.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatform.Repository
{
    public class BloggerRepository : IRepository<int,Blogger>

    {
        private readonly BlogPlatformContext _context;

        public BloggerRepository(BlogPlatformContext context)
        {
            _context = context;
        }

        public async Task<Blogger> GetByIdAsync(int bloggerId)
        {
            var blogger = await _context.Bloggers.FindAsync(bloggerId);
            if (blogger == null)
            {
                throw new NotFoundException($"Blogger with ID {bloggerId} not found.");
            }
            return blogger;

        }

       

        public async Task<Blogger> AddAsync(Blogger blogger)
        {

            try
            {
                var addblogger = _context.Bloggers.FirstOrDefault(x=>x.BloggerID == blogger.BloggerID);
                if (addblogger == null)
                {



                    await _context.Bloggers.AddAsync(blogger);
                    await _context.SaveChangesAsync();
                    return blogger;
                }
                else
                {
                    throw new DatabaseUpdateException("An error occurred while adding the blogger.",null);
                }


            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Blogger already exists");
                
            }
        }

        public async Task<Blogger> UpdateAsync(BloggerDTO blogger,int BloggerID)
        {
            var existingBlogger = await GetByIdAsync(blogger.BloggerID);
            if (existingBlogger == null)
            {
                existingBlogger.bio= blogger.Bio;
                existingBlogger.profilePicture= blogger.ProfilePicture;

                await _context.SaveChangesAsync();
                return existingBlogger;

            }

            throw new DatabaseUpdateException("An error occurred while updating the blogger.",null);
            
        }

        public async Task<string > DeleteAsync(int bloggerId)
        {

            var blogger = await GetByIdAsync(bloggerId);
            if(blogger == null)
            {
                _context.Bloggers.Remove(blogger);
                await _context.SaveChangesAsync();

                return $"The Blogger is removed with blogger id :{blogger.BloggerID}";

            }

            throw new Exception("Blogger delete failed");

           
        }

        public Task UpdateAsync(Blogger entity)
        {
            throw new NotImplementedException();
        }

        public Task<Blogger> Add(Blogger entity)
        {
            throw new NotImplementedException();
        }

        public Task<Blogger> Update(Blogger entity, int key)
        {
            throw new NotImplementedException();
        }

        public Task<Blogger> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Task<Blogger> Get(int key)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Blogger>> GetAll()
        {
            throw new NotImplementedException();
        }
    }

}

