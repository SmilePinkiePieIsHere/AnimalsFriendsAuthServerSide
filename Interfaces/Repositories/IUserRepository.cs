using AnimalsFriends.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace AnimalsFriends.Interfaces.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User user);

        List<User> GetUsers();

        User GetUserById(string id);
    }
}
