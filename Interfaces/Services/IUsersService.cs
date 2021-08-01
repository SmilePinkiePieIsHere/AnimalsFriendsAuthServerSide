using AnimalsFriends.Helpers;
using AnimalsFriends.Models;
using System.Collections.Generic;

namespace AnimalsFriends.Interfaces.Services
{
    public interface IUsersService
    {        
        List<User> GetAll(QueryParameters queryParameters);
    }
}
