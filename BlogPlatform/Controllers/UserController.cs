﻿using BlogPlatform.Interfaces;
using BlogPlatform.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BlogPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("UserRegistration")]

        public async Task<IActionResult> RegistrationUser(UserDTO userCreateDTO)
        {
            try
            {
                var user = await _userService.AddUserAsync(userCreateDTO);
                return Ok(user);
                //if (ModelState.IsValid)
                //{
                  
                //}
                //else
                //{
                //   // return BadRequest(new ErrorResponseDTO
                //    //{
                //    //    ErrorCode = 400,
                //    //    ErrorMessage = "one or more fields validate error"
                //    //});
                //}
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponseDTO
                //{
                  //  ErrorCode = 500,
                    //ErrorMessage = ex.Message,
                //});
            }
        }

        [HttpPost("UserLogin")]

        public async Task<IActionResult> LoginUser(LoginRequest loginRequest)
        {
            try
            {
                var user = await _userService.LoginUser(loginRequest);
                return Ok(user);
                //if (ModelState.IsValid)
                //{
                   
                //}
                //else
                //{
                //    //return BadRequest(new ErrorResponseDTO
                //    //{
                //    //    //ErrorCode = 400,
                //    //   ErrorMessage = "one or more fields validate error"
                //    //});
                //}
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                //return StatusCode(StatusCodes.Status401Unauthorized, new ErrorResponseDTO
                //{
                //    ErrorCode = 401,
                //    ErrorMessage = ex.Message
                //});
            }
        }

        //[HttpPut("ChangePassword")]
        //[Authorize]
        //public async Task<IActionResult> ChangePassword(ChangePasswordRequestDTO enitity)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var user = await _userService.ChangePassword(enitity, User);
        //            return Ok(user);
        //        }
        //        else
        //        {
        //            return BadRequest(new ErrorResponseDTO
        //            {
        //                ErrorCode = 400,
        //                ErrorMessage = "one or more fields validate error"
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status401Unauthorized, new ErrorResponseDTO
        //        {
        //            ErrorCode = 401,
        //            ErrorMessage = ex.Message
        //        });
        //    }
        //}
    }
}
