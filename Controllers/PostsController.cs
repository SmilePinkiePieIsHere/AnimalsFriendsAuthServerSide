using AnimalsFriends.Helpers;
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
        public PostsController(IPostService postService)
        {
            _postService = postService;
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
            return Ok(post);
        }

        [HttpPost]
        public ActionResult AddPost([FromBody] Post post)
        {
            _postService.Add(post);
            var test = CreatedAtAction("GetPost", new { id = post.Id }, post);
            return Ok(post);
        }
    }
}
