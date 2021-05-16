
using AnimalsFriends.Models;
using System.Linq;

namespace AnimalsFriends.Interfaces.Repositories
{
    public interface IPostRepository
    {
        IQueryable<Post> GetAll();

        Post Get(int id);

        void Add(Post post);

        void Update(Post post);

        void Delete(Post post);

        Post Find(int id);
    }
}
