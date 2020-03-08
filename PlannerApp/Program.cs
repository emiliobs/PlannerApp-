﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PlannerApp.Shared.Services;

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

            builder.RootComponents.Add<App>("app");

            await builder.Build().RunAsync();
        }
    }
}
