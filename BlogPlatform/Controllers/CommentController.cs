using BlogPlatform.Interfaces;
using BlogPlatform.Models;
using BlogPlatform.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase


    {

        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;

        }

        [HttpPost("AddComment")]

        public async Task<IActionResult> CommentPost(Comment comment)

        {
            try
            {
                var commentpost = await _commentService.AddCommentAsync(comment);
                return Ok(commentpost);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateComment")]

        public async Task<IActionResult> Commentupdate(CommentDTO commentDTO)
        {
            try
            {
                var updatecomment = await _commentService.UpdateCommentAsync(commentDTO);
                return Ok(updatecomment);
            }

            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        //[HttpDelete("DeletingComment")]

        //public async Task<IActionResult> DeleteComment( )
        //{
        //    try
        //    {
        //        var commentdelete = await _commentService.DeleteCommentAsync();
        //        return Ok(commentdelete);

        //    }
        //    catch (Exception ex)
        //    {

        //        return Bad
        //    }
        //}



    }
}
