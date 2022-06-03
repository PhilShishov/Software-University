
namespace Git.Services
{
    using System.Collections.Generic;

    using Git.Data;
    using Git.ViewModels.Repositories;

    public interface IRepositoryService
    {
        void Create(CreateRepositoryInputModel model);

        IEnumerable<RepositoryViewModel> GetPublicRepositories(string userId);

        Repository GetRepoById(string repoId);
    }
}
