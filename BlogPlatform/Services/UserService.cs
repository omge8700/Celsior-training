using System.Collections.Generic;
using System.Threading.Tasks;
using BlogPlatform.Models;
using BlogPlatform.Interfaces;
using BlogPlatform.Exceptions;
using BlogPlatform.Repository;
using BlogPlatform.Models.DTOs;
using System.Security.Cryptography;
using System.Text;


namespace BlogPlatform.Services
{
    public class UserService : IUserService
    {
       
        private readonly IRepository<string, User> _userRepo;



        private readonly ITokenService _tokenService;
        private readonly IRepository<int,Blogger> _bloggerRepository;

        public UserService(IRepository<string, User> userRepository, ITokenService tokenService, IRepository<int,Blogger> bloggerRepository)
        {
            _userRepo = userRepository;
            
            _tokenService = tokenService;
           
            _bloggerRepository = bloggerRepository;
        }






        public async Task<LoginResponse> AddUserAsync(UserDTO user)
        {
            HMACSHA256 hmac = new HMACSHA256();
            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.password));
            User newuser = new User()
            {
                username = user.Username,
                password = passwordHash,
                HashKey = hmac.Key,
                email = user.Email,
                role = user.Role
            };
            try
            {
                var addesUser = await _userRepo.Add(newuser);
                LoginResponse response = new LoginResponse()
                {
                    Username = addesUser.username,
                    Token = ""
                };
                if (user.Role == "blogger")
                {
                    var blogger = new Blogger { 
                    
                        bio = "",
                        profilePicture="",
                        userId = addesUser.userId,

                    };
                    await _bloggerRepository.Add(blogger);

                }
                
                return response ;
            }
            catch (Exception e)
            {
                
                throw new Exception("Could not register user");
            }
        }

        public async Task<LoginResponse> LoginUser(LoginRequest loginUser)
        {
            var user = await _userRepo.Get(loginUser.UserEmail);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            HMACSHA256 hmac = new HMACSHA256(user.HashKey);
            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginUser.Password));
            for (int i = 0; i < passwordHash.Length; i++)
            {
                if (passwordHash[i] != user.password[i])
                {
                    throw new Exception("Invalid username or password");
                }
            }
            return new LoginResponse()
            {
                Username = user.username,
                Token = await _tokenService.GenerateToken(new UserTokenDTO()
                {
                    username = user.username,
                    email = user.email,
                    Role = user.role.ToString(),
                })
            };
        }


            public Task<User> GetUserByIdAsync(int userid)
        {
            throw new NotImplementedException();
        }
    }
}
