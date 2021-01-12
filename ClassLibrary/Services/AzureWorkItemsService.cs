using ClassLibrary.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClassLibrary.Services
{
    public class AzureWorkItemsService : IAzureWorkItemsService
    {
        private readonly HttpClient _httpClient;
        private const string MyClient = "myclient";

        public AzureWorkItemsService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(MyClient);
        }
        
        public async Task<Iteration> GetIterations()
        {
            const string uri = "myTC%20Account%20Team/_apis/work/teamsettings/iterations?api-version=6.0";
            var response = await _httpClient.GetAsync(uri);
            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Iteration>(json);
        }

        public Task<WorkItem> GetWorkItemDetails(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Task<WorkItemIteration> GetWorkItems(string id)
        {
            throw new NotImplementedException();
        }
    }
}