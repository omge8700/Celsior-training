using BlogPlatform.Interfaces;
using BlogPlatform.Models;

namespace BlogPlatform.Services
{
    public class ReaderService : IReaderService
    {
        public Task AddReaderAsync(Reader reader)
        {

            
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
    }
}
