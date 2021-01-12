using ClassLibrary.Interfaces;
using Entities;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClassLibrary.Services
{
    public class AzureRepositoriesService : IAzureRepositoriesService
    {
        private readonly HttpClient _httpClient;
        private readonly HttpClient _httpClient2;
        private const string MyClient = "myclient";
        private const string MyClient2 = "myclient2";

        public AzureRepositoriesService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(MyClient);
            _httpClient2 = httpClientFactory.CreateClient(MyClient2);
        }

        public async Task<Repository> GetAllRepositories()
        {
            const string uri = "_apis/git/repositories/?api-version=6.0";
            var response = await _httpClient.GetAsync(uri);
            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Repository>(json);
        }

        public async Task<RepositoryBranch> GetAllRepositoryBranches(string id)
        {
            var uri = $"_apis/git/repositories/{id}/refs?api-version=5.0";
            var response = await _httpClient.GetAsync(uri);
            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<RepositoryBranch>(json);
        }

        public async Task<RepositoryFile> GetAllRepositoryFiles(string branch)
        {
            branch = branch.Replace("!","/").Replace("refs/heads/", "").Replace("refs/tags/", "");
            
            var uri = $"_apis/git/repositories/myTC%20Account/items?api-version=6.0&recursionLevel=Full&includeContentMetadata=true&versionDescriptor.versionType=branch&versionDescriptor.version={branch}";
            var response = await _httpClient.GetAsync(uri);
            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<RepositoryFile>(json);
        }

        public async Task<string> GetFile(string id)
        {
            var uri = $"_apis/git/repositories/myTC%20Account/blobs/{id}?api-version=6.1-preview.1&$format=text";
            var response = await _httpClient2.GetAsync(uri);
            var content = await response.Content.ReadAsStringAsync();

            return content;
        }
    }
}

//https://stackoverflow.com/questions/23438416/why-is-httpclient-baseaddress-not-working