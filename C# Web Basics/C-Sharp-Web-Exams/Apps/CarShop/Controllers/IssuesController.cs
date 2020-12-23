using CarShop.Services;
using CarShop.ViewModels.Cars;
using CarShop.ViewModels.Issues;

using SUS.HTTP;
using SUS.MvcFramework;

using System;
using System.Text.RegularExpressions;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IIssuesService issuesService;
        private readonly IUsersService usersService;

        public IssuesController(
            IIssuesService issuesService,
            IUsersService usersService)
        {
            this.issuesService = issuesService;
            this.usersService = usersService;
        }

        public HttpResponse CarIssues(string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var issuesViewModel = this.issuesService.GetModelById(carId);
            return this.View(issuesViewModel);
        }

        public HttpResponse Add(string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var model = new AddIssueViewModel()
            {
                CarId = carId,
            };

            return this.View(model);
        }

        [HttpPost]
        public HttpResponse Add(AddIssueInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }           

            if (string.IsNullOrEmpty(input.Description) || input.Description.Length < 5)
            {
                return this.Error("Description is required and should be at least 5 characters long.");
            }

            this.issuesService.AddIssue(input.Description, input.CarId);
            return this.Redirect($"/Issues/CarIssues?carId={input.CarId}");
        }

        public HttpResponse Fix(string issueId, string CarId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            if (!this.usersService.IsUserMechanic(userId))
            {
                return this.Error("Cannot fix issue! You are not a mechanic!");
            }

            var isFixed = this.issuesService.Fix(issueId, CarId);

            if (!isFixed)
            {
                return this.Error("Some error fixing issue");
            }

            return this.Redirect($"/Issues/CarIssues?carId={CarId}");
        }

        public HttpResponse Delete(string issueId, string CarId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var isDeleted = this.issuesService.Delete(issueId, CarId);

            if (!isDeleted)
            {
                return this.Error("Some error deleting issue");
            }

            return this.Redirect($"/Issues/CarIssues?carId={CarId}");
        }
    }
}
