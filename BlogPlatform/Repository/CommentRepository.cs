using BlogPlatform.Context;
using BlogPlatform.Exceptions;
using BlogPlatform.Interfaces;
using BlogPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatform.Repository
{
    public class CommentRepository : IRepository<Comment>
    {
        private readonly BlogPlatformContext _context;

        public CommentRepository(BlogPlatformContext context)
        {
            _context = context;
        }

        public async Task<Comment> GetByIdAsync(int commentId)
        {
            var comment = await _context.BlogComments.FindAsync(commentId);
            if (comment == null)
            {
                throw new NotFoundException($"Comment with ID {commentId} not found.");
            }
            return comment;
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _context.BlogComments.ToListAsync();
        }

        public async Task AddAsync(Comment comment)
        {
            try
            {
                await _context.BlogComments.AddAsync(comment);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DatabaseUpdateException("An error occurred while adding the comment.", ex);
            }
        }

        public async Task UpdateAsync(Comment comment)
        {
            var existingComment = await GetByIdAsync(comment.CommentId);
            if (existingComment == null)
            {
                throw new NotFoundException($"Comment with ID {comment.CommentId} not found.");
            }

            try
            {
                _context.BlogComments.Update(comment);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DatabaseUpdateException("An error occurred while updating the comment.", ex);
            }
        }

        public async Task DeleteAsync(int commentId)
        {
            var comment = await GetByIdAsync(commentId);
            _context.BlogComments.Remove(comment);
            await _context.SaveChangesAsync();
        }
    }
}
