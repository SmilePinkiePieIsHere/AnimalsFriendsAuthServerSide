using AnimalsFriends.Models;
using Microsoft.EntityFrameworkCore;
using AnimalsFriends.Interfaces.Repositories;
using System.Linq;

namespace PostsFriends.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly AnimalsFriendsContext _context;

        public PostRepository(AnimalsFriendsContext context)
        {
            _context = context;

            //_context.Database.EnsureCreated();
            //_context.SaveChanges();

            //PostsFriendsSeedDB.SeedPosts(context);  
        }

        public IQueryable<Post> GetAll()
        {
            return _context.Posts;
        }

        public Post Get(int id)
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

        public Post Find(int id)
        {
            return _context.Posts.Find(id);
        }
    }
}
