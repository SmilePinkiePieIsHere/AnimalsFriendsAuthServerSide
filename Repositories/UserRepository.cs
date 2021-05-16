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
        static List<User> users = new List<User>
        {
             //new TestUser
             // {
             //     SubjectId = "a9ea0f25-b964-409f-bcce-c92326624921",
             //     Username = "user",
             //     Password = "user123",
             // }
        };

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public User GetUserById(string id)
        {
            return users.Where(a => a.Id == id).FirstOrDefault();
        }

        public List<User> GetUsers()
        {
            return users;
        }
    }
}
