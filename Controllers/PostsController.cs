using AnimalsFriends.Helpers;
using AnimalsFriends.Interfaces.Repositories;
using AnimalsFriends.Interfaces.Services;
using AnimalsFriends.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var posts = _postService.GetAll(queryParameters);

            foreach (var post in posts)
            {
                var user = _userRepository.Get(post.UserId);
                post.User = new User
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName
                };
            }

            return Ok(posts);
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
            var user = _userRepository.Get(post.UserId);
            //post.User = new User
            //{
            //    Id = user.Id,
            //    FirstName = user.FirstName,
            //    LastName = user.LastName,
            //    UserName = user.UserName
            //};
            //post.PublishedOn = DateTime.Now;

            _postService.Add(post);
            //post
            return Ok("");
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePost([FromRoute] string id, [FromBody] Post post)
        {
            if (id != post.Id.ToString())
            {
                return BadRequest();
            }

            try
            {
                _postService.Update(post);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpDelete("{id}")]
        public ActionResult RemovePost([FromRoute] string id)
        {
            var post = _postService.Find(Guid.Parse(id));

            if (post == null)
            {
                return NotFound();
            }

            _postService.Delete(post);

            return Ok(post); //(ActionResult)animal
        }
    }
}
