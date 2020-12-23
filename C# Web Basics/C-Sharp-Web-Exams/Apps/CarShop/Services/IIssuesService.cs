using CarShop.ViewModels.Issues;

namespace CarShop.Services
{
    public interface IIssuesService
    {
        void AddIssue(string description, string carId);

        IssueOverviewViewModel GetModelById(string carId);

        bool Fix(string issueId, string carId);

        bool Delete(string issueId, string carId);
    }
}
