using AnimalsFriends.Helpers;
using AnimalsFriends.Models;
using AnimalsFriends.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using AnimalsFriends.Interfaces.Services;
using System;

namespace AnimalsFriends.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public List<Animal> GetAll(AnimalQueryParameters queryParameters)
        {
            IQueryable<Animal> animals = _animalRepository.GetAll();

            if (queryParameters.Status != null)
            {
                animals = animals.Where(a => queryParameters.Status.Contains(a.CurrentStatus.ToLower()));
            }

            if (queryParameters.Gender != null)
            {
                animals = animals.Where(a => queryParameters.Gender.Contains(a.Gender.ToLower()));
            }

            if (queryParameters.Species != null)
            {
                animals = animals.Where(a => queryParameters.Species.Contains(a.Species.ToLower()));
            }

            if (animals.Count() > 0)
            {
                animals = animals
               .Skip(queryParameters.Size * (queryParameters.Page - 1))
               .Take(queryParameters.Size);
            }

            return animals.ToList();
        }

        public Animal Get(Guid id)
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

        public Animal Find(Guid id)
        {
            return _animalRepository.Find(id);
        }
    }
}
