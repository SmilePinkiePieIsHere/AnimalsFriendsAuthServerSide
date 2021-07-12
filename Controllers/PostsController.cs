using AnimalsFriends.Helpers;
using AnimalsFriends.Interfaces.Repositories;
using AnimalsFriends.Interfaces.Services;
using AnimalsFriends.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace AnimalsFriends.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IUserRepository _userRepository;
        public PostsController(IPostService postService, IUserRepository userRepository)
        {
            _postService = postService;
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll([FromQuery] PostQueryParameters queryParameters)
        {
            return Ok(_postService.GetAll(queryParameters));
        }


        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult GetPost(Guid id)
        {
            var post = _postService.Get(id);
            if (post == null)
            {
                return NotFound();
            }

            var user = _userRepository.Get(post.UserId);
            post.User = new User
            {
                Id =  user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName
            };

            return Ok(post);
        }

        [HttpPost]
        public ActionResult AddPost([FromBody] Post post)
        {
            _postService.Add(post);
            //var test = CreatedAtAction("GetPost", new { id = post.Id }, post);
            return Ok(post);
        }
    }
}
