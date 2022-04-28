namespace P02.After.Contracts
{
    public interface IUser
    {
        string Email { get; }

        string PasswordHash { get; }
    }
}
