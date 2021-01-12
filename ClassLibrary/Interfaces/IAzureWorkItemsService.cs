using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
   public  interface IAzureWorkItemsService
    {
        Task<Iteration> GetIterations();

        Task<WorkItemIteration> GetWorkItems(string id);

        Task<WorkItem> GetWorkItemDetails(IEnumerable<int> ids);
        
    }
}