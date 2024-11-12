using BlogPlatform.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloggerController : ControllerBase
    {
        private readonly IBloggerService _bloggerService;

        public BloggerController(IBloggerService bloggerservice)
        {
            _bloggerService = bloggerservice;
            
        }

        [HttpPost("")]
    }
}
