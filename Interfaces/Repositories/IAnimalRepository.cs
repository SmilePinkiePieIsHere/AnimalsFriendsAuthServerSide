using AnimalsFriends.Models;
using System.Collections.Generic;
using System.Linq;

namespace AnimalsFriends.Interfaces.Repositories
{
    public interface IAnimalRepository
    {
        IQueryable<Animal> GetAll();

        Animal Get(int id);

        void Add(Animal animal);

        void Update(Animal animal);

        void Delete(Animal animal);

        Animal Find(int id);
    }
}
