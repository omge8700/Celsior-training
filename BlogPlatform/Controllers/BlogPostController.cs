using BlogPlatform.Interfaces;
using BlogPlatform.Services;
using BlogPlatform.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {

        private readonly ILogger<BlogPostController> _logger;
        private readonly IBlogPostService _blogPostService;

        public BlogPostController(IBlogPostService blogPostService, ILogger<BlogPostController> logger)
        {
            _blogPostService = blogPostService; 
            _logger = logger;


        }

        [HttpPost("BlogPost")]

        public async Task<IActionResult> BlogPosting(BlogPostDTO blogPostDTO)
        {
            try
            {
                var blogposting = await _blogPostService.AddPostAsync(blogPostDTO);
                return Ok(blogposting);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);


            }


        }

        [HttpPut("UpdatePost")]

        public async Task<IActionResult> BlogUpdate(BlogPostDTO blogupdatedto,int PostId)
        {
            try
            {
                var blogupdate = await _blogPostService.UpdatePostAsync(blogupdatedto,PostId);
                return Ok(blogupdate);

            }

            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }

        }

        [HttpGet("BlogPostId")]

        public async Task<IActionResult> GetPostId( int PostId)
        {
            try
            {
                var getBlogId = await _blogPostService.GetPostByIdAsync(PostId);
                return Ok(getBlogId);

            }
            catch (Exception ex)
            {

                return BadRequest($"{ex.Message}");
            }

        }





    }
}
