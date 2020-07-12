using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Configuration;
using StarOJ.Client.Models;
using StarOJ.Models;

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
            services.Configure<OJOptions>(configuration.GetSection("Options"));
            services.Configure<BuildStatus>(configuration.GetSection("Build"));
        }
    }
}
