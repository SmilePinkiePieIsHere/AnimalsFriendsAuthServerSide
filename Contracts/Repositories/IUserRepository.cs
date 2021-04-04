using IdentityServer4.Test;
using System.Collections.Generic;

namespace AnimalsFriends.Contracts.Repositories
{
    public interface IUserRepository
    {
        void AddUser(TestUser user);

        List<TestUser> GetUsers();

        TestUser GetUserById(string id);
    }
}
