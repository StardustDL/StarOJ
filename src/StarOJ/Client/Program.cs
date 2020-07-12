using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AcBlog.Extensions;
using StarOJ.Client.Models;
using StarOJ.Sdk;
using StarOJ.Sdk.Api;

namespace StarOJ.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddSingleton(new RuntimeOptions { IsPrerender = false });

            builder.Services.AddUIComponents();

            builder.Services.AddHttpClient("StarOJ.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("StarOJ.ServerAPI"));

            builder.Services.AddApiAuthorization();

            builder.Services.AddSingleton<IOJService, ApiOJService>();

            await builder.UseExtensions();

            await builder.Build().RunAsync();
        }
    }
}
