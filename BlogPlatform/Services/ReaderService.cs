using BlogPlatform.Interfaces;
using BlogPlatform.Models;
using BlogPlatform.Models.DTOs;

namespace BlogPlatform.Services
{
    public class ReaderService : IReaderService
    {
        public Task AddReaderAsync(Reader reader)
        {
            throw new NotImplementedException();
            
        }

        public Task<string> AddReaderAsync(ReaderDTO reader)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReaderAsync(int readerId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reader>> GetAllReadersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Reader> GetReaderByIdAsync(int readerId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateReaderAsync(Reader reader)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateReaderAsync(ReaderDTO reader)
        {
            throw new NotImplementedException();
        }
    }
}
