namespace MilitaryElite.Factories
{
    using MilitaryElite.Models;

    public class EngineerFactory
    {
        public Engineer MakeEngineer(string[] args)
        {
            string id = args[1];
            string firstName = args[2];
            string lastName = args[3];
            decimal salary = decimal.Parse(args[4]);
            string corp = args[5];

            Engineer engineer = new Engineer(id, firstName, lastName, salary, corp);

            return engineer;
        }
    }
}
