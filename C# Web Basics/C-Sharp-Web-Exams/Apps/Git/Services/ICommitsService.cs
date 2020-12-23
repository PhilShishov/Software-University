using Git.ViewModels.Commits;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface  ICommitsService
    {
        void Create(string repoId, string description,string userId);

        IEnumerable<ComitViewModel> GetALL(string userId);

        void Delete(int id,string userId);


    }
}
