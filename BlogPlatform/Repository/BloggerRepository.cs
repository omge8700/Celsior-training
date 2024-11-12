using BlogPlatform.Context;
using BlogPlatform.Exceptions;
using BlogPlatform.Interfaces;
using BlogPlatform.Models;
using BlogPlatform.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlogPlatform.Repository
{
    public class BloggerRepository : IRepository<int,Blogger>

    {
        private readonly BlogPlatformContext _context;

        public BloggerRepository(BlogPlatformContext context)
        {
            _context = context;
        }

       
        
        public async Task<Blogger> Add(Blogger entity)
        {
            try
            {
              
               
                    await _context.Bloggers.AddAsync(entity);
                    await _context.SaveChangesAsync();
                    return entity;
                
                
                


            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Blogger already exists");

            }
        }

        public async Task<Blogger> Update(Blogger entity, int key)
        {
            var existingBlogger = await  Get(key);
            if (existingBlogger != null)
            {
                existingBlogger.bio = entity.bio;
                existingBlogger.profilePicture = entity.profilePicture;

                await _context.SaveChangesAsync();
                return existingBlogger;

            }

            throw new DatabaseUpdateException("An error occurred while updating the blogger.", null);

        }

        public async  Task<Blogger> Delete(int key)
        {

            var blogger = await Get(key);
            if (blogger != null)
            {
                _context.Bloggers.Remove(blogger);
                await _context.SaveChangesAsync();

                return blogger;

            }

            throw new Exception("Blogger delete failed");


        }

        public async Task<Blogger> Get(int key)
        {
            var blogger = await _context.Bloggers.FirstOrDefaultAsync(x=>x.BloggerID==key);
            if (blogger == null)
            {
                throw new NotFoundException($"Blogger with ID {key} not found.");
            }
            return blogger;


        }

        public async Task<IEnumerable<Blogger>> GetAll()
        {
           var allbloggers = await _context.Bloggers.ToListAsync();
           if(allbloggers.Count > 0)
            {
                return allbloggers;
            }

            throw new Exception($"not found the list");
        }
    }

}

