using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BlogPlatform.Models
{
    public class User
    {
        public int  userId { get; set; } 

        public IEnumerable<Blogger> Bloggers { get; set; }

        public string username { get; set; } = string.Empty;

        public byte[] password { get; set; } 

        public string email { get; set; } = string.Empty;

        public string role { get; set; } = string.Empty;

        public byte[] HashKey { get; set; }

        

        public User() { } 
        


    }
}
