using IdentityServer4.Test;
using AnimalsFriends.Contracts.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AnimalsFriends.Repositories
{
    public class UserRepository : IUserRepository
    {
        static List<TestUser> users = new List<TestUser>
        {
             new TestUser
              {
                  SubjectId = "a9ea0f25-b964-409f-bcce-c92326624921",
                  Username = "admin",
                  Password = "admin",
              }
        };

        public void AddUser(TestUser user)
        {
            users.Add(user);
        }

        public TestUser GetUserById(string id)
        {
            return users.Where(a => a.SubjectId == id).FirstOrDefault();
        }

        public List<TestUser> GetUsers()
        {
            return users;
        }
    }
}
