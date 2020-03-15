using AKSoftware.WebApi.Client;
using PlannerApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApp.Shared.Services
{
    public class AuthenticationService
    {
        private readonly string _baseUrl;

        ServiceClient client = new ServiceClient();

        public AuthenticationService(string baseUrl)
        {
            this._baseUrl = baseUrl;
        }


        public async Task<UserManagerResponse> RegisterUserAsync(RegisterRequest registerRequest)
        {
            var response = await client.PostAsync<UserManagerResponse>($"{_baseUrl}/api/auth/register",registerRequest);
            return response.Result;
        }

        public async Task<UserManagerResponse> LoginUserAsync(LoginRequest request)
        {
            var response = await client.PostAsync<UserManagerResponse>($"{_baseUrl}/api/auth/login", request);
            return response.Result;
        }
    }
}
