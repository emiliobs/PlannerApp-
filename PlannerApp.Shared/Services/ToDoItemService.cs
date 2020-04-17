using AKSoftware.WebApi.Client;
using PlannerApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApp.Shared.Services
{
    public class ToDoItemService
    {
        private readonly string _url;
        ServiceClient client = new ServiceClient();

        public ToDoItemService(string url)
        {
            this._url = url;
        }

        public string AccessToken 
        { 
            get => client.AccessToken;
            set 
            {
                client.AccessToken = value;
            }
        }

        /// <summary>
        ///   Insert a new ToDo item inside a specific Plan
        /// </summary>
        /// <param name="model">object represnts the item to be added</param>
        /// <returns></returns>

        public async Task<ToDoItemSingleResponse> CreateItemAsync(ToDoItemRequest model)
        {
            var response = await client.PostProtectedAsync<ToDoItemSingleResponse>($"{_url}/api/todoitems", model);

            return response.Result;
        }

        /// <summary>
        ///   Edit the description of a specific item
        /// </summary>
        /// <param name="model">object represnts the item to be Edited</param>
        /// <returns></returns>
        public async Task<ToDoItemSingleResponse> EditItemAsync(ToDoItemRequest model)
        {
            var response = await client.PutProtectedAsync<ToDoItemSingleResponse>($"{_url}/api/todoitems", model);

            return response.Result;
        }

        /// <summary>
        ///  Mark the item as done if it is undone and vice verse 
        /// </summary>
        /// <param name="model">ID of the item to be Update.</param>
        /// <returns></returns>
        public async Task<ToDoItemSingleResponse> ChangeItemStateAsync(string id)
        {
            var response = await client.PutProtectedAsync<ToDoItemSingleResponse>($"{_url}/api/todoitems/{id}", null);

            return response.Result;
        }

        /// <summary>
        ///  Delete  the Description of a specific item
        /// </summary>
        /// <param name="model">ID of the item to be Delete.</param>
        /// <returns></returns>
        public async Task<ToDoItemSingleResponse> DeleteItemAsync(string id)
        {
            var response = await client.DeleteProtectedAsync<ToDoItemSingleResponse>($"{_url}/api/todoitems/{id}");

            return response.Result;
        }
    }
}
