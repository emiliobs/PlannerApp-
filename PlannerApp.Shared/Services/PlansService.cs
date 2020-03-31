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
        public async Task<PlanCollectionPagingResponse> GetAllPlansByPageAsync(int page = 1)
        {
            var response = await client.GetProtectedAsync<PlanCollectionPagingResponse>($"{_baseUrl}/api/plans?page={page}");
            return response.Result;
        }

        /// <summary>
        ///Retrieve all the plans from the API with pagination:  
        /// </summary>
        /// <param name="page">Number of the page</param>
        /// <returns></returns>
        public async Task<PlanCollectionPagingResponse> SearchPlansByPageAsync(string query, int page = 1)
        {
            var response = await client.GetProtectedAsync<PlanCollectionPagingResponse>($"{_baseUrl}/api/plans/search?query={query}&page={page}");
            return response.Result;
        }

        /// <summary>
        ///  Post a plan to the API
        /// </summary>
        /// <param name="model">onject represent the plam to be added</param>
        /// <returns></returns>
        /// <summary>
        /// Post a plan to the API
        /// </summary>
        /// <param name="model">object represnets the plan to be added</param>
        /// <returns></returns>
        public async Task<PlanSingleResponse> PostPlanAsync(PlanRequest model)
        {
            var response = await client.SendFormProtectedAsync<PlanSingleResponse>($"{_baseUrl}/api/plans", ActionType.POST, new StringFormKeyValue("Title", model.Title), new StringFormKeyValue("Description", model.Description), new FileFormKeyValue("CoverFile", model.CoverFile, model.FileName));

            return response.Result;
        }

    }
}
