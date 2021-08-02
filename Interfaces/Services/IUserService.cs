using AnimalsFriends.Helpers;
using AnimalsFriends.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalsFriends.Interfaces.Services
{
    public interface IUserService
    {
        Task<OWinResponseToken> Register(User user);

        Task<OWinResponseToken> Login(User user);

        Task<OWinResponseToken> Refresh(string refreshToken);

        List<User> GetAll(QueryParameters queryParameters);

        User Get(string id);

        void Delete(User user);

        User Find(string id);
    }
}
