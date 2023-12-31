﻿using CafeManiaApi.Application.DTOs;
using CafeManiaApi.Application.Interfaces;
using CafeManiaApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CafeManiaApi.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        public readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {

            try
            {
                return Ok(_userService.GetUserAll());
            }
            catch (Exception e)
            {
                return BadRequest("Error:" + e);

            }
        }


        [HttpPost("RegisterUser")]
        public IActionResult RegisterUser(UserDTO user)
        {
            try
            {
                _userService.AddUser(user);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Error:"+ e);
                
            }
            
        }

        [HttpPost("UpdateUser")]
        public IActionResult UpdateUser(UserDTO user)
        {
            try
            {
                _userService.UpdateUser(user);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Error:" + e);

            }

        }


        [HttpPost("LoginUser")]
        public IActionResult LoginUser(UserDTO user)
        {
            try
            {
                return Ok(_userService.LoginUser(user));
            }
            catch (Exception e)
            {
                return BadRequest("Error:" + e);

            }

        }







    }
}
