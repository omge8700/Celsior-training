using BlogPlatform.Context;
using BlogPlatform.Exceptions;
using BlogPlatform.Interfaces;
using BlogPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatform.Repository
{
    public class CommentRepository : IRepository<int, Comment>

    {
        private readonly BlogPlatformContext _context;

        public CommentRepository(BlogPlatformContext  context)
        {
            _context = context;
            
        }

        public async  Task<Comment> Add(Comment entity)
        {
            try
            {
                var commentonpost = _context.BlogComments.FirstOrDefault(x => x.CommentId == entity.CommentId);
                if (commentonpost != null) {

                    await _context.BlogComments.AddAsync(entity);
                    await _context.SaveChangesAsync();
                    return entity;
                }
                else
                {
                    throw new Exception("Comment could not be found ");
                }

            }
            catch (Exception ex) 
            {
                throw new Exception($"Comment could not be added");

            }
            
        }

        public async Task<Comment> Delete(int key)
        {
            var deletecomment = await Get(key);
            if (deletecomment != null)
            {
                _context.BlogComments.Remove(deletecomment);
                await _context.SaveChangesAsync();
                return deletecomment;

            }
            throw new Exception("Comment  Delete Failed");

        }

        public async Task<Comment> Get(int key)
        {
           var gettingcomment = _context.BlogComments.FirstOrDefault(x=>x.CommentId == key);
            return gettingcomment;
        }

        public async Task<IEnumerable<Comment>> GetAll()
        {
            var getcomment = _context.BlogComments.ToList();
            if (getcomment.Any())
            {
                return getcomment;
            }
            throw new Exception("Comments Collection is empty");

        }

        public async Task<Comment> Update(Comment entity, int key)
        {
            var updatecomment = await Get(key);
            if (updatecomment != null)
            {
                
              
                updatecomment.Content = entity.Content;
                await _context.SaveChangesAsync();
                return updatecomment;


            }
            throw new Exception("Update post failed");

        }
    }
}
