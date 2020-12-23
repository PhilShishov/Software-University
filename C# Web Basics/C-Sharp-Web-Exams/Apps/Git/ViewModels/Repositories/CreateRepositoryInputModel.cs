using System;

namespace Git.ViewModels.Repositories
{
    public class CreateRepositoryInputModel
    {
        public string Name { get; set; }

        public string RepositoryType { get; set; }

        public string OwnerId { get; set; }

    }
}
