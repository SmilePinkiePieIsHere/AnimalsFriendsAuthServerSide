using AnimalsFriends.Interfaces.Repositories;
using AnimalsFriends.Interfaces.Services;
using AnimalsFriends.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Linq;
using AnimalsFriends.Helpers;

namespace AnimalsFriends.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private static readonly HttpClient client = new HttpClient();

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OWinResponseToken> Register(User user)
        {              
            user.PasswordSalt = GenerateSalt();
            user.PasswordHash = GenerateHash(user.PasswordHash, user.PasswordSalt);
            _userRepository.Add(user);

            var values = new Dictionary<string, string>
                {
                    { "client_id", "testClient" },
                    { "client_secret", "test" },
                    { "scope", "AnimalsFriends offline_access" },
                    { "grant_type", "password" },
                    { "username", user.UserName },
                    { "password", user.PasswordHash }
                };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("https://localhost:44337/api/identity/connect/token", content);

            OWinResponseToken data = new OWinResponseToken();

            if (response.IsSuccessStatusCode)
            {
                var responseString = JObject.Parse(await response.Content.ReadAsStringAsync());
                var res = JsonConvert.DeserializeObject<dynamic>(responseString.ToString());

                data.AccessToken = res.access_token;
                data.ExpirationInSeconds = res.expires_in;
                data.TokenType = res.token_type;
                data.RefreshToken = res.refresh_token;
            }
            else
            {
                data.ErrorDescription = "Something bad happens.";
            }

            return data;
        }

        public async Task<OWinResponseToken> Login(User user)
        {
            var searchedUser = _userRepository.GetAll().ToList().Find(u => u.UserName.ToLower() == user.UserName.ToLower() || u.Email.ToLower() == user.Email.ToLower());
            user.PasswordHash = GenerateHash(user.PasswordHash, searchedUser.PasswordSalt);

            OWinResponseToken data = new OWinResponseToken();
            if (searchedUser.PasswordHash != user.PasswordHash)
            {
                data.ErrorDescription = "Password is uncorrect.";
                return data;
            }

            var values = new Dictionary<string, string>
                {
                    { "client_id", "testClient" },
                    { "client_secret", "test" },
                    { "scope", "AnimalsFriends offline_access" },
                    { "grant_type", "password" },
                    { "username", searchedUser.UserName },
                    { "password", user.PasswordHash }
                };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("https://localhost:44337/api/identity/connect/token", content);            

            if (response.IsSuccessStatusCode)
            {
                var responseString = JObject.Parse(await response.Content.ReadAsStringAsync());
                var res = JsonConvert.DeserializeObject<dynamic>(responseString.ToString());

                data.AccessToken = res.access_token;
                data.ExpirationInSeconds = res.expires_in;
                data.TokenType = res.token_type;
                data.RefreshToken = res.refresh_token;
                data.UserId = searchedUser.Id;
                data.IsAdmin = searchedUser.IsAdmin;
            }
            else
            {
                data.ErrorDescription = "Wrong username or password.";
            }

            return data;
        }

        public async Task<OWinResponseToken> Refresh(string refreshToken)
        {
            var values = new Dictionary<string, string>
                {
                    { "client_id", "testClient" },
                    { "client_secret", "test" },
                    { "scope", "AnimalsFriends offline_access" },
                    { "grant_type", "refresh_token" },
                    { "refresh_token", refreshToken }
                };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("https://localhost:44337/api/identity/connect/token", content);

            OWinResponseToken data = new OWinResponseToken();

            if (response.IsSuccessStatusCode)
            {
                var responseString = JObject.Parse(await response.Content.ReadAsStringAsync());
                var res = JsonConvert.DeserializeObject<dynamic>(responseString.ToString());

                data.AccessToken = res.access_token;
                data.ExpirationInSeconds = res.expires_in;
                data.TokenType = res.token_type;
                data.RefreshToken = res.refresh_token;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }

            return data;
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

        public User Get(string id)
        {
            return _userRepository.Get(id);
        }

        public void Delete(User user)
        {
            _userRepository.Delete(user);
        }

        public User Find(string id)
        {
            return _userRepository.Find(id);
        }

        private byte[] GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        private string GenerateHash(string password, byte[] passwordSalt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                                   password: password,
                                   salt: passwordSalt,
                                   prf: KeyDerivationPrf.HMACSHA1,
                                   iterationCount: 10000,
                                   numBytesRequested: 256 / 8));
        }
    }
}
