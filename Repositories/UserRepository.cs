using AnimalsFriends.Interfaces.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AnimalsFriends.Models;

namespace AnimalsFriends.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AnimalsFriendsContext _context;

        public UserRepository(AnimalsFriendsContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User Get(string id)
        {
            return _context.Users.Where(a => a.Id == id).FirstOrDefault();
        }        

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
