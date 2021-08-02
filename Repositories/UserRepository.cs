using AnimalsFriends.Interfaces.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AnimalsFriends.Models;
using System;

namespace AnimalsFriends.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AnimalsFriendsContext _context;

        public UserRepository(AnimalsFriendsContext context)
        {
            _context = context;
        }

        public IQueryable<User> GetAll()
        {
            return _context.Users;
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

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public User Find(string id)
        {
            return _context.Users.Find(id);
        }
    }
}
