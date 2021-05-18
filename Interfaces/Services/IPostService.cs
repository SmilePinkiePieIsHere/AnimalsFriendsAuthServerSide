
using AnimalsFriends.Helpers;
using AnimalsFriends.Models;
using System;
using System.Collections.Generic;

namespace AnimalsFriends.Interfaces.Services
{
    public interface IPostService
    {
        List<Post> GetAll(PostQueryParameters queryParameters);

        Post Get(Guid id);

        void Add(Post post);

        void Update(Post post);

        void Delete(Post post);

        Post Find(Guid id);
    }
}
