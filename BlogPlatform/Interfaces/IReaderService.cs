using System.Collections.Generic;
using System.Threading.Tasks;
using BlogPlatform.Models;


namespace BlogPlatform.Interfaces
{
    public interface IReaderService
    {
        Task<Reader> GetReaderByIdAsync(int readerId);
        Task<IEnumerable<Reader>> GetAllReadersAsync();
        Task AddReaderAsync(Reader reader);
        Task UpdateReaderAsync(Reader reader);
        Task DeleteReaderAsync(int readerId);

    }
}
