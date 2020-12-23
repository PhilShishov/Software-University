using Git.Data;
using Git.ViewModels.Repositories;
using System.Collections.Generic;

namespace Git.Services
{
    public interface IRepositoriService
    {
        void Create(CreateRepositoryInputModel model);

        IEnumerable<RepositoryViewModel> GetPublicRepositories(string userId);

        Repository GetRepoById(string repoId); 
    }
}
