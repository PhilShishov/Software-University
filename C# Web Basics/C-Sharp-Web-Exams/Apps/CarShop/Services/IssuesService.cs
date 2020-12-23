using System.Linq;

using CarShop.Data;
using CarShop.Data.Models;
using CarShop.ViewModels.Issues;

namespace CarShop.Services
{
    public class IssuesService : IIssuesService
    {
        private readonly ApplicationDbContext db;

        public IssuesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddIssue(string description, string carId)
        {
            var issue = new Issue
            {
                Description = description,
                CarId = carId,
            };

            this.db.Issues.Add(issue);
            this.db.SaveChanges();
        }

        public IssueOverviewViewModel GetModelById(string carId)
        {
            var issues = this.db.Issues.Where(x => x.CarId == carId)
             .Select(x => new IssueViewModel
             {
                 Id = x.Id,
                 Description = x.Description,
                 Status = x.IsFixed == true ? "Yes" : "Not yet",
             }).ToList();

            var model = new IssueOverviewViewModel()
            {
                CarId = carId,
                CarModel = GetCarModel(carId),
                Issues = issues,
            };

            return model;
        }

        public bool Delete(string issueId, string carId)
        {
            var issue = this.GetDetails(issueId, carId);

            if (issue == null)
            {
                return false;
            }

            this.db.Issues.Remove(issue);
            this.db.SaveChanges();
            return true;
        }

        public bool Fix(string issueId, string carId)
        {
            var issue = this.GetDetails(issueId, carId);

            if (issue == null)
            {
                return false;
            }

            issue.IsFixed = true;

            this.db.Issues.Update(issue);
            this.db.SaveChanges();
            return true;
        }

        private Issue GetDetails(string issueId, string carId)
        => this.db.Issues.FirstOrDefault(x => x.Id == issueId && x.CarId == carId);

        private string GetCarModel(string carId)
        => this.db.Cars.Where(x => x.Id == carId).Select(x => x.Year.ToString() + " " + x.Model).FirstOrDefault();
    }
}