using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BlogPlatform.Models
{
    public class User
    {
        public int  userId { get; set; } 

        public string username { get; set; } = string.Empty;

        public string password { get; set; } = string.Empty;

        public string email { get; set; } = string.Empty;

        public string role { get; set; } = string.Empty;

        public User() { } 
        
        public  string Register()
        {
            return " user registerd succesfully";

        }

        public string Login()
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes("Secret key");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier,this.userId.ToString()),
                    new Claim(ClaimTypes.Name,this.username)

                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenhandler.CreateToken(tokenDescriptor);
            return tokenhandler.WriteToken(token);

        }
    }
}
