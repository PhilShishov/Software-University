namespace P02.After
{
    using Contracts;

    public class AccountController
    {
        private readonly IAccountManager manager;

        public AccountController(IAccountManager manager)
        {
            this.manager = manager;
        }

        public void ChangePassword(string oldPass, string newPass)
        {
            this.manager.ChangePassword(oldPass, newPass);
        }
    }
}
