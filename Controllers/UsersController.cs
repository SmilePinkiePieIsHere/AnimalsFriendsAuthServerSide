using AnimalsFriends.Helpers;
using AnimalsFriends.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsFriends.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [Authorize]
        [Route("users")]
        [HttpGet]
        public IActionResult GetAll([FromQuery] QueryParameters queryParameters)
        {
            return Ok(_usersService.GetAll(queryParameters));
        }
    }
}