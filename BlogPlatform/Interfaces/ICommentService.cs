using System.Collections.Generic;
using System.Threading.Tasks;
using BlogPlatform.Models;
using BlogPlatform.Models.DTOs;



namespace BlogPlatform.Interfaces
{
    public interface ICommentService
    {
        Task<Comment> GetCommentByIdAsync(int commentId);
        Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int postId);
        Task  <string> AddCommentAsync(Comment comment);
        Task <string> UpdateCommentAsync(CommentDTO comment);
        Task  DeleteCommentAsync(int  commentId);

    }
}
