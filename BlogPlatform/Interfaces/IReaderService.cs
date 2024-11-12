using System.Collections.Generic;
using System.Threading.Tasks;
using BlogPlatform.Models;
using BlogPlatform.Models.DTOs;


namespace BlogPlatform.Interfaces
{
    public interface IReaderService
    {
        Task<Reader> GetReaderByIdAsync(int readerId);
        Task<IEnumerable<Reader>> GetAllReadersAsync();
        Task <string>AddReaderAsync(ReaderDTO reader);
        Task <string> UpdateReaderAsync(ReaderDTO reader);
        Task DeleteReaderAsync(int readerId);

    }
}
