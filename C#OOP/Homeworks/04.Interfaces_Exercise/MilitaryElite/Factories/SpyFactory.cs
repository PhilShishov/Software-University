namespace MilitaryElite.Factories
{
    using MilitaryElite.Models;


    public class SpyFactory
    {
        public Spy MakeSpy(string[] args)
        {
            string id = args[1];
            string firstName = args[2];
            string lastName = args[3];
            int codeNumber = int.Parse(args[4]);

            Spy spy = new Spy(id, firstName, lastName, codeNumber);

            return spy;
        }
    }
}
