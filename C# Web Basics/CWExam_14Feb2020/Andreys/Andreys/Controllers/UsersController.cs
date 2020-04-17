namespace Andreys.Controllers
{
    using Andreys.Services;
    using Andreys.ViewModels;
    using Andreys.ViewModels.Users;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {
            var userId = this.usersService.GetUserId(input.Username, input.Password);
            if (userId != null)
            {
                this.SignIn(userId);
                return this.Redirect("/");
            }

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (string.IsNullOrWhiteSpace(input.Email))
            {
                //return this.Error("Email cannot be empty!");
                return this.View();
            }

            if (input.Password.Length < 6 || input.Password.Length > 20)
            {
                //return this.Error("Password must be at least 6 characters and at most 20");
                return this.View();
            }

            if (input.Username.Length < 4 || input.Username.Length > 10)
            {
                //return this.Error("Username must be at least 4 characters and at most 10");
                return this.View();
            }

            if (input.Password != input.ConfirmPassword)
            {
                //return this.Error("Password should match.");
                return this.View();
            }

            if (this.usersService.EmailExists(input.Email))
            {
                //return this.Error("Email already in use.");
                return this.View();
            }

            if (this.usersService.UsernameExists(input.Username))
            {
                //return this.Error("Username already in use.");
                return this.View();
            }

            this.usersService.Register(input.Username, input.Email, input.Password);
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.SignOut();
            return this.Redirect("/");
        }
    }
}