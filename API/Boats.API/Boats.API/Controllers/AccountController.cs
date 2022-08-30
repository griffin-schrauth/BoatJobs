﻿using AutoMapper;
using Boats.API.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Boats.API.Models;

namespace Boats.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;

        public AccountController(UserManager<ApiUser> userManager,  ILogger<AccountController> logger, IMapper mapper)
        {
            _userManager = userManager;
            
            _logger = logger;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            _logger.LogInformation($"Registration Attempt for {userDTO.Email} ");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = _mapper.Map<ApiUser>(userDTO);
                user.UserName = userDTO.Email;
                // this prev line is because identity requires username. we are just using the email to be the same at the username. After testing make sure we 
                //change this
                var result = await _userManager.CreateAsync(user, userDTO.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                await _userManager.AddToRolesAsync(user, userDTO.Roles);
                return Accepted();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(Register)}");
                return Problem($"Something Went Wrong in the {nameof(Register)}", statusCode: 500);
            }

        }

        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> Login([FromBody] LoginUserDTO userDTO)
        //{
        //    _logger.LogInformation($"Login Attempt for {userDTO.Email} ");
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    try
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(userDTO.Email, userDTO.Password, false, false);

        //        if(!result.Succeeded)
        //        {
        //            return Unauthorized(userDTO);
        //        }

        //        return Accepted();

        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"Something Went Wrong in the {nameof(Login)}");
        //        return Problem($"Something Went Wrong in the {nameof(Login)}", statusCode: 500);
        //    }

        //}
    }
}
