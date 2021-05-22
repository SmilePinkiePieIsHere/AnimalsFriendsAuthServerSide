using AnimalsFriends.Models;
using System;
using System.Linq;

namespace AnimalsFriends.Interfaces.Repositories
{
    public interface IAnimalRepository
    {
        IQueryable<Animal> GetAll();

        Animal Get(Guid id);

        void Add(Animal animal);

        void Update(Animal animal);

        void Delete(Animal animal);

        Animal Find(Guid id);
    }
}
