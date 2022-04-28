namespace P02.After.Contracts
{
    using System.Collections.Generic;

    public interface IAccountFinder
    {
        IEnumerable<IUser> GetAllUsersOnline();

        IEnumerable<IUser> GetAllUsers();

        IUser GetUserByName(string name);
    }
}
