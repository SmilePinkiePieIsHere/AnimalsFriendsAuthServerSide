using AnimalsFriends.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace AnimalsFriends.Interfaces.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();

        User Get(string id);

        void Add(User user);
    }
}
