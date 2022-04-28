namespace P02.After.Contracts
{
    public interface IAccountManager
    {
        void ChangePassword(string oldPass, string newPass);
    }
}
