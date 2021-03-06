using AnimalsFriends.Models;
using Microsoft.EntityFrameworkCore;
using AnimalsFriends.Interfaces.Repositories;
using System.Linq;
using System;

namespace PostsFriends.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly AnimalsFriendsContext _context;

        public PostRepository(AnimalsFriendsContext context)
        {
            _context = context;
        }

        public IQueryable<Post> GetAll()
        {
            return _context.Posts;
        }

        public Post Get(Guid id)
        {
            return _context.Posts.Find(id);
        }

        public void Add(Post Post)
        {
            _context.Posts.Add(Post);
            _context.SaveChanges();
        }

        public void Update(Post Post)
        {
            _context.Entry(Post).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Post Post)
        {
            _context.Posts.Remove(Post);
            _context.SaveChanges();
        }

        public Post Find(Guid id)
        {
            return _context.Posts.Find(id);
        }
    }
}
