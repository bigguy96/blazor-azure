using ClassLibrary.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

        public async Task<WorkItem> GetWorkItemDetails(IEnumerable<int> ids)
        {
            const string uri = "_apis/wit/workitemsbatch?api-version=6.0";
            var batch = new WorkItemsBatch
            {
                ids = ids.ToArray(),
                fields = new[]
                {
                    "System.Id",
                    "System.Title",
                    "System.WorkItemType",
                    "System.IterationPath",
                    "System.AssignedTo",
                    "Microsoft.VSTS.TCM.ReproSteps",
                    "Microsoft.VSTS.Common.AcceptanceCriteria",
                    "System.Description"
                }
            };
            var jsonString = JsonSerializer.Serialize(batch);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<WorkItem>(json);
        }

        public async Task<WorkItemIteration> GetWorkItems(string id)
        {
            var uri = $"myTC%20Account%20Team/_apis/work/teamsettings/iterations/{id}/workitems?api-version=6.0-preview.1";
            var response = await _httpClient.GetAsync(uri);
            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<WorkItemIteration>(json);
        }
    }
}