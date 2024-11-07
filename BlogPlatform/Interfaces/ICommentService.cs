using System.Collections.Generic;
using System.Threading.Tasks;
using BlogPlatform.Models;



namespace BlogPlatform.Interfaces
{
    public interface ICommentService
    {
        Task<Comment> GetCommentByIdAsync(int commentId);
        Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int postId);
        Task AddCommentAsync(Comment comment);
        Task UpdateCommentAsync(Comment comment);
        Task DeleteCommentAsync(int commentId);

    }
}
