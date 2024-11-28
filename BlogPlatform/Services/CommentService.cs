using BlogPlatform.Interfaces;
using BlogPlatform.Models;
using BlogPlatform.Models.DTOs;

namespace BlogPlatform.Services
{
    public class CommentService :ICommentService
    {

        private readonly IRepository<int, Comment> _commentrepo;

        public CommentService(IRepository<int ,Comment> commentRepository)
        {
            _commentrepo = commentRepository;
            

        }

        public async Task<string> AddCommentAsync(Comment comment)
        {
            Comment addingcomment = new Comment()
            {
                Likes = comment.Likes,
                CommentId = comment.CommentId,
                Content = comment.Content,

            };

            try
            {
                var addcomment = await _commentrepo.Add(addingcomment);
                return $"the commment is added";
            }
            catch (Exception ex)
            {
                throw new Exception("Could not be comment");

            }
            
            
        }

        public async Task DeleteCommentAsync(int commentId)
        {
            try
            {
                var checkcommentid = await _commentrepo.Get(commentId);
                if (checkcommentid != null) {

                    await _commentrepo.Delete(commentId);
                    
                }

                

            }

            catch
            {
                throw new Exception("Comment delete failde");

            }
           

        }

        public async Task<Comment> GetCommentByIdAsync(int commentId)
        {
            var getiingcomment = await _commentrepo.Get(commentId);
            return getiingcomment;
        }

        public async Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int postId)
        {
            
            var gettingallcomments = await _commentrepo.GetAll();
            throw new NotImplementedException();


        }

        public async Task<string> UpdateCommentAsync(CommentDTO comment)
        {
            throw new NotImplementedException();
        }
    }
}
