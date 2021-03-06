using System;
using System.Threading.Tasks;
using AnimalsFriends.Helpers;
using AnimalsFriends.Interfaces.Services;
using AnimalsFriends.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsFriends.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public async Task<OWinResponseToken> Register(User user)
        {
            return await _userService.Register(user);
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public async Task<OWinResponseToken> Login(User user)
        {
            return await _userService.Login(user);
        }

        [AllowAnonymous]
        [Route("refresh_token")]
        [HttpPost]
        public async Task<OWinResponseToken> Refresh([FromBody]string refreshToken)
        {
            return await _userService.Refresh(refreshToken);
        }

        [Route("msg")]
        [HttpPost]
        public string GetUserMsg()
        {
            return " is authenticated";
        }

        [Authorize]
        [Route("users")]
        [HttpGet]
        public IActionResult GetAll([FromQuery] QueryParameters queryParameters)
        {
            return Ok(_userService.GetAll(queryParameters));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult GetUser(string id)
        {
            var user = _userService.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult RemoveUser([FromRoute] string id)
        {
            var user = _userService.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.Delete(user);

            return Ok(user);
        }
    }
}