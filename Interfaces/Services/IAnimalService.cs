﻿using AnimalsFriends.Helpers;
using AnimalsFriends.Models;
using System.Collections.Generic;

namespace AnimalsFriends.Interfaces.Services
{
    public interface IAnimalService
    {
        List<Animal> GetAll(AnimalQueryParameters queryParameters);

        Animal Get(int id);

        void Add(Animal animal);

        void Update(Animal animal);

        void Delete(Animal animal);

        Animal Find(int id);
    }
}
