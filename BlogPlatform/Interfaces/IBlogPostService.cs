using System.Collections.Generic;
using System.Threading.Tasks;
using BlogPlatform.Models;
using BlogPlatform.Models.DTOs;


namespace BlogPlatform.Interfaces
{
    public interface IBlogPostService
    {
        Task<BlogPost> GetPostByIdAsync(int postId);
        Task<IEnumerable<BlogPost>> GetAllPostsAsync();
       
        Task<string> UpdatePostAsync(BlogPostDTO post,int PostId);
        Task<string> DeletePostAsync(BlogPostDTO post,int PostId);
        Task<string> AddPostAsync(BlogPostDTO blogpost);
    }
}
