
namespace Git.Services
{
    using System.Collections.Generic;

    using Git.ViewModels.Commits;

    public interface ICommitsService
    {
        void Create(string repoId, string description, string userId);

        IEnumerable<ComitViewModel> GetALL(string userId);

        void Delete(int id, string userId);


    }
}
