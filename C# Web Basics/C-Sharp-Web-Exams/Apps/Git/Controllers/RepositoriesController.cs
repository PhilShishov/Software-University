using Git.Services;
using Git.ViewModels.Repositories;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoriService repositoriesService;

        public RepositoriesController(IRepositoriService repositoriesService )
        {
            this.repositoriesService = repositoriesService;
        }



        public HttpResponse All()
        {
            var userId = this.GetUserId();
            var repos = this.repositoriesService.GetPublicRepositories(userId);


            return this.View(repos);
        }


        public HttpResponse Create()
        {
            return this.View();
        }


        [HttpPost]
        public HttpResponse Create(CreateRepositoryInputModel model)
        {

            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(model.Name) || model.Name.Length<3 || model.Name.Length>10)
            {
                return this.Error("Name is required and should be between 3 and 10 charecters");
            }

            model.OwnerId = this.GetUserId();



            this.repositoriesService.Create(model);
            return this.Redirect("/Repositories/All");

        }






    }
}
