using System.Collections.Generic;
using System.Threading.Tasks;
using BlogPlatform.Models;


namespace BlogPlatform.Interfaces
{
    public interface IBlogPostService
    {
        Task<BlogPost> GetPostByIdAsync(int postId);
        Task<IEnumerable<BlogPost>> GetAllPostsAsync();
        Task AddPostAsync(BlogPost post);
        Task UpdatePostAsync(BlogPost post);
        Task DeletePostAsync(int postId);


    }
}
