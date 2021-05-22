using AnimalsFriends.Helpers;
using AnimalsFriends.Interfaces.Repositories;
using AnimalsFriends.Interfaces.Services;
using AnimalsFriends.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalsFriends.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public List<Post> GetAll(PostQueryParameters queryParameters)
        {
            IQueryable<Post> posts = _postRepository.GetAll();

            //if (queryParameters.Category != null)
            //{
            //    posts = posts.Where(a => a.Category == queryParameters.Category.ToLower());
            //}

            if (posts.Count() > 0)
            {
                posts = posts
               .Skip(queryParameters.Size * (queryParameters.Page - 1))
               .Take(queryParameters.Size);
            }

            return posts.ToList();
        }

        public Post Get(Guid id)
        {
            return _postRepository.Get(id);
        }

        public void Add(Post post)
        {
            _postRepository.Add(post);
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }

        public void Delete(Post post)
        {
            _postRepository.Delete(post);
        }

        public Post Find(Guid id)
        {
            return _postRepository.Find(id);
        }
    }
}
