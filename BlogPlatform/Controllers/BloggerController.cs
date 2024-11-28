using BlogPlatform.Interfaces;
using BlogPlatform.Models;
using BlogPlatform.Models.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class BloggerController : ControllerBase
    {
        private readonly IBloggerService _bloggerService;

        public BloggerController(IBloggerService bloggerservice)
        {
            _bloggerService = bloggerservice;
            
        }

        [HttpPost("AddingBloggers")]

        public async Task<IActionResult> AddBlogger(BloggerDTO bloggerDTO)
        {
            try
            {
                var addblogger = await _bloggerService.AddBloggerAsync(bloggerDTO, 1);
                return Ok(addblogger);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut("UpdatingBlogger")]

        public async Task<IActionResult> UpdateBlogger(BloggerDTO bloggerDTO,int BloggerID)

        {
            try
            {
                var bloggerupdate = await _bloggerService.UpdateBloggerAsync(bloggerDTO, BloggerID);
                return Ok(bloggerupdate);

            }

            catch (Exception ex)
            {

                return BadRequest($"{ex.Message} ");
            }

        }

        [HttpGet("BloggerId")]

        public async Task<IActionResult> GetBloggerId(int BloggerID)
        {
            try
            {
                var getbloggerId = await _bloggerService.GetBloggerByIdAsync(BloggerID);
                return Ok(getbloggerId);

            }
            catch (Exception ex)
            {

                return BadRequest($"{ex.Message}");
            }

        }

        [HttpGet("AllBloggerIds")]

        public async Task<IActionResult> GetAllBloggers(Blogger blogger)
        {
            try
            {
                var getallbloggers = await _bloggerService.GetBloggerListAsync();
                return Ok(getallbloggers);
            }

            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }


                
        }



        
    }
}
