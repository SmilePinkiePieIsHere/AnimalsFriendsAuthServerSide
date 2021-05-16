using AnimalsFriends.Helpers;
using AnimalsFriends.Models;
using AnimalsFriends.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using AnimalsFriends.Interfaces.Services;

namespace AnimalsFriends.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalService(IAnimalRepository animalRepository, AnimalsFriendsContext context)
        {
            _animalRepository = animalRepository;
        }

        public List<Animal> GetAll(AnimalQueryParameters queryParameters)
        {
            IQueryable<Animal> animals = _animalRepository.GetAll();

            if (queryParameters.Status != null)
            {
                animals = animals.Where(a => a.CurrentStatus.ToString().ToLower() == queryParameters.Status.ToLower());
            }

            if (queryParameters.Gender != null)
            {
                animals = animals.Where(a => a.Gender.ToString().ToLower() == queryParameters.Gender.ToLower());
            }

            if (queryParameters.Species != null)
            {
                animals = animals.Where(a => a.Species.ToString().ToLower() == queryParameters.Species.ToLower());
            }

            if (animals.Count() > 0)
            {
                animals = animals
               .Skip(queryParameters.Size * (queryParameters.Page - 1))
               .Take(queryParameters.Size);
            }            
          
            return  animals.ToList();
        }

        public Animal Get(int id)
        {
            return _animalRepository.Get(id);
        }

        public void Add(Animal animal)
        {
            _animalRepository.Add(animal);
        }

        public void Update(Animal animal)
        {
            _animalRepository.Update(animal);
        }

        public void Delete(Animal animal)
        {
            _animalRepository.Delete(animal);
        }

        public Animal Find(int id)
        {
            return _animalRepository.Find(id);
        }
    }
}
