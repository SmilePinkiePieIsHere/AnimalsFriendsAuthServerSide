using AnimalsFriends.Interfaces.Repositories;
using AnimalsFriends.Interfaces.Services;
using AnimalsFriends.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using AnimalsFriends.Helpers;

namespace AnimalsFriends.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _userRepository;
        private static readonly HttpClient client = new HttpClient();

        public UsersService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
       
        public List<User> GetAll(QueryParameters queryParameters)
        {
            IQueryable<User> users = _userRepository.GetAll();

            if (users.Count() > 0)
            {
                users = users
               .Skip(queryParameters.Size * (queryParameters.Page - 1))
               .Take(queryParameters.Size);
            }

            return users.ToList();
        }       
    }
}
