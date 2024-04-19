using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SocialNetworkBaigiamasis.DTO;
using SocialNetworkBaigiamasis.Models;
using SocialNetworkBaigiamasis.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;

namespace SocialNetworkBaigiamasis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private IConfiguration _config;

        public UserController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpPut("[action]")]
        public ActionResult Register(UserCreateDTO user) //endpoint priima zinute apie user
        {
            _userService.Register(user);
            return Ok();
        }

        [HttpPost("[action]")]
        public IActionResult Login([FromBody] LoginDTO loginRequest) //tikrina ar yra user
        {
            int userId;
            try
            {
                userId = _userService.Login(loginRequest.UserName, loginRequest.Password);
            }
            catch (AuthenticationException)
            {
                return Unauthorized();
            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var Sectoken = new JwtSecurityToken(
              _config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              new Claim[]
              {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString())
              },
              expires: DateTime.Now.AddMonths(1),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return Ok($"Bearer {token}");
        }
        [HttpDelete("[action]")]
        [Authorize]
        public IActionResult DeleteUser(int userID)
        {
            int loggedInUserId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            UserRoles role =  _userService.GetUserRole(loggedInUserId);
            if(role != UserRoles.Admin)
            {
                return Unauthorized();
            }
            _userService.DeleteUser(userID);
            return Ok();
        }

    }
}
