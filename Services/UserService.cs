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
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

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
            var searchedUser = _userRepository.GetAll().Find(u => u.UserName.ToLower() == user.UserName.ToLower());
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
                    { "username", user.UserName },
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
