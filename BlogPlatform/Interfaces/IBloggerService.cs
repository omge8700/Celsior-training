using System.Collections.Generic;
using System.Threading.Tasks;
using BlogPlatform.Models;
using BlogPlatform.Models.DTOs;


namespace BlogPlatform.Interfaces
{
    public interface IBloggerService
    {
        Task<BloggerDTO> GetBloggerByIdAsync(int BloggerId);

        Task<IEnumerable<BloggerDTO>> GetBloggerListAsync(int BloggerID );

        Task <string>AddBloggerAsync(BloggerDTO blogger,int BloggerId);

        Task <string>UpdateBloggerAsync(BloggerDTO blogger,int BloggerId);

        Task<string> DeleteBloggerAsync(BloggerDTO blogger,int BloggerId); 

    }
}
