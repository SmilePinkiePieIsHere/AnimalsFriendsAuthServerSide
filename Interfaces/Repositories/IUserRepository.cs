using AnimalsFriends.Models;
using System;
using System.Linq;

namespace AnimalsFriends.Interfaces.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();

        User Get(string id);

        void Add(User user);

        void Delete(User animal);

        User Find(string id);
    }
}
