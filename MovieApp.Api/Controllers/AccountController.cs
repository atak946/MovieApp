using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieApp.Api.Identity;
using MovieApp.Application.Dtos;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountController (
            UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager,
            IConfiguration configuration
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]UserLoginDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.UserName);

            if (user == null)
            {
                return Unauthorized();
            }
            else
            {
                return await TrySign(user, dto.Password);
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]UserRegisterDto dto)
        {
            var result = await _userManager.CreateAsync(new IdentityUser() { Email = dto.Email, UserName = dto.UserName }, dto.Password);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(dto.UserName);

                return await TrySign(user, dto.Password);

            }
            else
                return Ok(result.Errors);
        }

        [HttpGet]
        public async Task<IdentityUser> Get()
        {
            var result = await _userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            return result;
        }

        private async Task<IActionResult> TrySign(IdentityUser user, string Password)
        {
            var signIn = await _signInManager.PasswordSignInAsync(user, Password, false, false);

            if (signIn != null && signIn.Succeeded)
            {
                return Ok(new AccessTokenGenerator(_configuration, user).GenerateToken());
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
