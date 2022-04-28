namespace P02.Before.Contracts
{
    public interface IUser
    {
        string Email { get; }

        string PasswordHash { get; }
    }
}
