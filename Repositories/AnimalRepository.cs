using IdentityServer4.Test;
using AnimalsFriends.Configuration;
using AnimalsFriends.Interfaces.Repositories;
using AnimalsFriends.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace AnimalsFriends.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly AnimalsFriendsContext _context;

        public AnimalRepository(AnimalsFriendsContext context)
        {
            _context = context;
        }

        public IQueryable<Animal> GetAll()
        {
            return _context.Animals;
        }

        public Animal Get(Guid id)
        {
            return _context.Animals.Find(id);
        }

        public void Add(Animal animal)
        {
            _context.Animals.Add(animal);
            _context.SaveChanges();
        }

        public void Update(Animal animal)
        {
            _context.Entry(animal).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Animal animal)
        {
            _context.Animals.Remove(animal);
            _context.SaveChanges();
        }

        public Animal Find(Guid id)
        {
            return _context.Animals.Find(id);
        }
    }
}
