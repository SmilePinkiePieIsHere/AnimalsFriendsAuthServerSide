using IdentityServer4.Test;
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

        public void AddUser(User user)
        {
            _context.Users.Add(user);
        }

        public User GetUserById(string id)
        {
            return _context.Users.Where(a => a.Id == id).FirstOrDefault();
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}
