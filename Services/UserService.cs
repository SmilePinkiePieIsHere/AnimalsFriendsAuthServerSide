﻿using IdentityServer4.Test;
using AnimalsFriends.Interfaces.Repositories;
using AnimalsFriends.Interfaces.Services;
using AnimalsFriends.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

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
            //TestUser newUser = new TestUser
            //{
            //    Username = user.Username,
            //    Password = user.Password,
            //    SubjectId = Guid.NewGuid().ToString()
            //};

            ApplicationUser newUser = new ApplicationUser
            {
                Username = user.Username,
                Password = user.Password,
                SubjectId = Guid.NewGuid().ToString()
            };

            _userRepository.AddUser(newUser);

            IdentityResult result = await UserManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();

            //var values = new Dictionary<string, string>
            //    {
            //        { "client_id", "testClient" },
            //        { "client_secret", "test" },
            //        { "scope", "AnimalsFriends offline_access" },
            //        { "grant_type", "password" },
            //        { "username", newUser.Username },
            //        { "password", newUser.Password }
            //    };

            //var content = new FormUrlEncodedContent(values);

            //var response = await client.PostAsync("https://localhost:44337/api/identity/connect/token", content);

            //OWinResponseToken data = new OWinResponseToken();

            //if (response.IsSuccessStatusCode)
            //{
            //    var responseString = JObject.Parse(await response.Content.ReadAsStringAsync());
            //    var res = JsonConvert.DeserializeObject<dynamic>(responseString.ToString());

            //    data.AccessToken = res.access_token;
            //    data.ExpirationInSeconds = res.expires_in;
            //    data.TokenType = res.token_type;
            //    data.RefreshToken = res.refresh_token;
            //}
            //else
            //{
            //    data.ErrorDescription = "Something bad happens.";
            //}

            //return data;
        }

        public async Task<OWinResponseToken> Login(User user)
        {
            var values = new Dictionary<string, string>
                {
                    { "client_id", "testClient" },
                    { "client_secret", "test" },
                    { "scope", "AnimalsFriends offline_access" },
                    { "grant_type", "password" },
                    { "username", user.Username },
                    { "password", user.Password }
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
    }
}
