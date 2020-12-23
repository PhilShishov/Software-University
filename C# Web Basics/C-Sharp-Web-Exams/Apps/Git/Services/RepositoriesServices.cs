using Git.Data;
using Git.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Git.Services
{
    class RepositoriesServices : IRepositoriService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesServices(ApplicationDbContext db)
        {
            this.db = db;
        }


        public void Create(CreateRepositoryInputModel model)
        {
            var repository = new Repository()
            {
                Name = model.Name,
                CreatedOn = DateTime.UtcNow,
                IsPublic = model.RepositoryType == "Public" ? true : false,
                OwnerId = model.OwnerId,
            };

            this.db.Repositories.Add(repository);
            this.db.SaveChanges();
        }

        public IEnumerable<RepositoryViewModel> GetPublicRepositories(string userId)
        {
            var repositories = this.db.Repositories.Where(r => r.IsPublic && r.OwnerId == userId)
                .Select(r => new RepositoryViewModel
                { Name = r.Name,
                   Id = r.Id,
                   CratedOn = r.CreatedOn.ToString("s"),
                   Owner = r.Owner.Username,
                   Commits = r.Commits.Count
                }).ToList();

            return repositories;
        }

        public Repository GetRepoById(string repoId)
        {
            return this.db.Repositories.Where(r => r.Id == repoId).FirstOrDefault();
        }
    }

}
