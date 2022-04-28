namespace P02.Before
{
    using Contracts;

    public class AccountController
    {
        private readonly IAccount manager;

        public AccountController(IAccount manager)
        {
            this.manager = manager;
        }

        public void ChangePassword(string oldPass, string newPass)
        {
            this.manager.ChangePassword(oldPass, newPass);
        }
    }
}
