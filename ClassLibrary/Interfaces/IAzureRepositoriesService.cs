using Entities;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface IAzureRepositoriesService
    {
        Task<Repository> GetAllRepositories();

        Task<RepositoryBranch> GetAllRepositoryBranches(string id);

        Task<RepositoryFile> GetAllRepositoryFiles(string branch);

        Task<string> GetFile(string id);
    }
}