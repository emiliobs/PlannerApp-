using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PlannerApp.Shared.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Blazor.FileReader;

namespace PlannerApp
{
    public class Program
    {

        private static string URL = "https://plannerappserver20200228091432.azurewebsites.net";

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddScoped<AuthenticationService>(a =>
            {
                return new AuthenticationService(URL);
            });
            
            builder.Services.AddScoped<PlansService>(s => 
            {
                return new PlansService(URL);
            });

            builder.Services.AddScoped<ToDoItemService>(s => 
            {
                return new ToDoItemService(URL);
            });

            builder.Services.AddFileReaderService(options => 
            {
                options.UseWasmSharedBuffer = true;
            });
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
          builder.Services.AddScoped<AuthenticationStateProvider, LocalAutheticationStateProvider>();
           
            builder.RootComponents.Add<App>("app");

            await builder.Build().RunAsync();
        }
    }
}
