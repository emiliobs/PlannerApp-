using AKSoftware.WebApi.Client;
using PlannerApp.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannerApp.Shared.Services
{
    public class PlansService
    {
        private readonly string _baseUrl;
        private readonly ServiceClient client = new ServiceClient();

        public PlansService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }


        public string AccessToken
        {
            get => client.AccessToken;
            set => client.AccessToken = value;
        }


        /// <summary>
        ///Retrieve all the plans from the API with pagination:  
        /// </summary>
        /// <param name="id">ID of the plan to be retrieved</param>
        /// <returns></returns>
        public async Task<PlanCollectionPagingResponse> GetAllPlansByPageAsync(int page = 1)
        {
            HttpRequestResult<PlanCollectionPagingResponse> response = await client.GetProtectedAsync<PlanCollectionPagingResponse>($"{_baseUrl}/api/plans?page={page}");
            return response.Result;
        }

        /// <summary>
        ///Return a Plan by ID
        /// </summary>
        /// <param name="page">Number of the page</param>
        /// <returns></returns>
        public async Task<PlanSingleResponse> GetPlansByIdAsync(string id)
        {
            HttpRequestResult<PlanSingleResponse> response = await client.GetProtectedAsync<PlanSingleResponse>($"{_baseUrl}/api/plans/{id}");
            return response.Result;
        }

        /// <summary>
        ///Retrieve all the plans from the API with pagination:  
        /// </summary>
        /// <param name="page">Number of the page</param>
        /// <returns></returns>
        public async Task<PlanCollectionPagingResponse> SearchPlansByPageAsync(string query, int page = 1)
        {
            HttpRequestResult<PlanCollectionPagingResponse> response = await client.GetProtectedAsync<PlanCollectionPagingResponse>($"{_baseUrl}/api/plans/search?query={query}&page={page}");
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

            List<FormKeyValue> formKeyValue = new List<FormKeyValue>()
            {
                
                new StringFormKeyValue("Title", model.Title),
                new StringFormKeyValue("Description", model.Description),
            };

            if (model.CoverFile != null)
                           formKeyValue.Add(new FileFormKeyValue("CoverFile", model.CoverFile, model.FileName));
           
            HttpRequestResult<PlanSingleResponse> response = await client.SendFormProtectedAsync<PlanSingleResponse>($"{_baseUrl}/api/plans", ActionType.POST, 
              formKeyValue.ToArray() );

            return response.Result;
        }

        /// <summary>
        /// Edit   a plan to the API
        /// </summary>
        /// <param name="model">onject represent the plam to be added</param>
        /// <returns></returns>
        /// <summary>
        /// Post a plan to the API
        /// </summary>
        /// <param name="model">object represnets the plan to be added</param>
        /// <returns></returns>
        public async Task<PlanSingleResponse> EditPlanAsync(PlanRequest model)
        {

            List<FormKeyValue> formKeyValue = new List<FormKeyValue>()
            {
                new StringFormKeyValue("Id", model.Id),
                new StringFormKeyValue("Title", model.Title),                                                                                    
                new StringFormKeyValue("Description", model.Description),
            };

            if (model.CoverFile != null)
            {
                formKeyValue.Add(new FileFormKeyValue("CoverFile", model.CoverFile, model.FileName));

            }
            
              HttpRequestResult<PlanSingleResponse> response = await client.SendFormProtectedAsync<PlanSingleResponse>($"{_baseUrl}/api/plans", ActionType.POST,
                                                            formKeyValue.ToArray());
                 return response.Result;

            
           

        }

    }
}
