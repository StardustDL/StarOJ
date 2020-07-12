using StarOJ.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StarOJ.Sdk.Api
{
    public class ApiOJService : IOJService
    {
        public ApiOJService(HttpClient httpClient)
        {
            HttpClient = httpClient;

            JudgerService = new JudgerService(HttpClient);
        }

        public HttpClient HttpClient { get; }

        public IJudgerService JudgerService { get; }

        const string PrepUrl = "/api";

        public async Task<OJOptions> GetOptions(CancellationToken cancellationToken = default)
        {
            using var responseMessage = await HttpClient.GetAsync($"{PrepUrl}/System/Options", cancellationToken).ConfigureAwait(false);
            responseMessage.EnsureSuccessStatusCode();
            return await responseMessage.Content.ReadFromJsonAsync<OJOptions>(cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
