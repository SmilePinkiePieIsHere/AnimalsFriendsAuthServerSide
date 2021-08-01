using AnimalsFriends.Models;
using System.Linq;

namespace AnimalsFriends.Interfaces.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();

        User Get(string id);

        void Add(User user);
    }
}
