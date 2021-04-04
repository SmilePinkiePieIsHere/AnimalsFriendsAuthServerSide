using AnimalsFriends.Helpers;
using AnimalsFriends.Models;
using System.Collections.Generic;

namespace AnimalsFriends.Contracts.Services
{
    public interface IAnimalService
    {
        List<Animal> GetAll(AnimalQueryParameters queryParameters);

        Animal GetAnimal(int id);

        void AddAnimal(Animal animal);

        void UpdateAnimal(Animal animal);

        void DeleteAnimal(Animal animal);

        Animal FindAnimal(int id);
    }
}
