namespace MilitaryElite.Factories
{
    using MilitaryElite.Models;

    public class PrivateFactory
    {
        public Private MakePrivateSoldier(string[] args)
        {
            string id = args[1];
            string firstName = args[2];
            string lastName = args[3];
            decimal salary = decimal.Parse(args[4]);

            Private privateSoldier = new Private(id, firstName, lastName, salary);

            return privateSoldier;
        }
    }
}
