using BlogPlatform.Models.DTOs;

namespace BlogPlatform.Interfaces
{
    
    
        public interface ITokenService
        {
            public Task<string> GenerateToken(UserTokenDTO user);
        }
    
}
