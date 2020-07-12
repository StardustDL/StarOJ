using StarOJ.Models.Judging;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace StarOJ.Sdk.Api
{
    internal class JudgerService : IJudgerService
    {
        public JudgerService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public HttpClient HttpClient { get; }

        const string PrepUrl = "/api/Judger";

        public async Task<string?> Create(JudgingTask task, CancellationToken cancellationToken = default)
        {
            using var responseMessage = await HttpClient.PostAsJsonAsync($"{PrepUrl}", task, cancellationToken).ConfigureAwait(false);
            responseMessage.EnsureSuccessStatusCode();
            return await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
        }

        public async Task<JudgingTask?> Get(string id, CancellationToken cancellationToken = default)
        {
            using var responseMessage = await HttpClient.GetAsync($"{PrepUrl}/{id}", cancellationToken).ConfigureAwait(false);
            responseMessage.EnsureSuccessStatusCode();
            return await responseMessage.Content.ReadFromJsonAsync<JudgingTask?>(cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
