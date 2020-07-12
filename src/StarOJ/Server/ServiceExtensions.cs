using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Configuration;
using StarOJ.Client.Models;
using StarOJ.Models;
using StarOJ.Server.Models;
using Judge0;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System;
using System.Threading.Tasks;

namespace StarOJ.Server
{
    public static class ServiceExtensions
    {
        public static void AddServerPrerenderAuthorization(this IServiceCollection services)
        {
            services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
            services.AddScoped<SignOutSessionStateManager>();
        }

        public static void AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppOptions>(configuration.GetSection("Options"));
            services.Configure<Judge0Options>(configuration.GetSection("Judge0"));
            services.Configure<OJOptions>(configuration.GetSection("Options"));
            services.Configure<BuildStatus>(configuration.GetSection("Build"));
        }

        public static void AddJudge0(this IServiceCollection services)
        {
            services.AddHttpClient("judge0", (sp, client) =>
            {
                var options = sp.GetRequiredService<IOptions<Judge0Options>>().Value;
                var uri = options.Uri;
                if (!uri.EndsWith("/")) uri += "/";
                client.BaseAddress = new Uri(uri);
            });

            services.AddScoped<IJudge0Service, Judge0Service>(sp =>
            {
                var options = sp.GetRequiredService<IOptions<Judge0Options>>().Value;
                var http = sp.GetRequiredService<IHttpClientFactory>().CreateClient("judge0");

                return new Judge0Service(http);
            });
        }

        public static async Task Authenticate(this IJudge0Service service, Judge0Options options)
        {
            {
                var result = await service.AuthenticationService.Authenticate(options.AuthenticationToken);
                if (!result.Result)
                {
                    throw new Exception("Judge0 Authenticate failed.");
                }
            }
            {
                var result = await service.AuthenticationService.Authorize(options.AuthorizationToken);
                if (!result.Result)
                {
                    throw new Exception("Judge0 Authorize failed.");
                }
            }
        }
    }
}
