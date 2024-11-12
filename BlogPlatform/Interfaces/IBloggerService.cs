using System.Collections.Generic;
using System.Threading.Tasks;
using BlogPlatform.Models;
using BlogPlatform.Models.DTOs;


namespace BlogPlatform.Interfaces
{
    public interface IBloggerService
    {
        Task<Blogger> GetBloggerByIdAsync(int BloggerId);

        Task<IEnumerable<Blogger>> GetBloggerListAsync( );

        Task <string>AddBloggerAsync(BloggerDTO blogger,int BloggerId);

        Task <string>UpdateBloggerAsync(BloggerDTO blogger,int BloggerId);

        Task<string> DeleteBloggerAsync(BloggerDTO blogger,int BloggerId); 

    }
}
