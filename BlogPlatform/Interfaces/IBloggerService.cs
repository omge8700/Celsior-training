using System.Collections.Generic;
using System.Threading.Tasks;
using BlogPlatform.Models;


namespace BlogPlatform.Interfaces
{
    public interface IBloggerService
    {
        Task<Blogger> GetBloggerByIdAsync(int bloggerId);

        Task<IEnumerable<Blogger>> GetBloggerListAsync();

        Task AddBloggerAsync(Blogger blogger);

        Task UpdateBloggerAsync(Blogger blogger);

        Task DeleteBloggerAsync(int bloggerId); 

    }
}
