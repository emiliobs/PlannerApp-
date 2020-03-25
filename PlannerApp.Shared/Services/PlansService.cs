using AKSoftware.WebApi.Client;
using PlannerApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApp.Shared.Services
{
    public class PlansService
    {
        private readonly string _baseUrl;

        ServiceClient client = new ServiceClient();

        public PlansService(string baseUrl)
        {
            this._baseUrl = baseUrl;
        }


        public string AccessToken 
        {
            get=> client.AccessToken;
            set 
            {
                client.AccessToken = value;  
            }
        }


        /// <summary>
        ///Retrieve all the plans from the API with pagination:  
        /// </summary>
        /// <param name="page">Number of the page</param>
        /// <returns></returns>
        public   async Task<PlanCollectionPagingResponse> GetAllPlansByPageAsync(int page)
        {
            var response = await client.GetProtectedAsync<PlanCollectionPagingResponse>($"{_baseUrl}/api/plans?page={page}");
            return response.Result;
        }

        /// <summary>
        ///Retrieve all the plans from the API with pagination:  
        /// </summary>
        /// <param name="page">Number of the page</param>
        /// <returns></returns>
        public async Task<PlanCollectionPagingResponse> SearchPlansByPageAsync(string query,int page = 1)
        {
            var response = await client.GetProtectedAsync<PlanCollectionPagingResponse>($"{_baseUrl}/api/plans?query={query}&page={page}");
            return response.Result;
        }

    }
}
