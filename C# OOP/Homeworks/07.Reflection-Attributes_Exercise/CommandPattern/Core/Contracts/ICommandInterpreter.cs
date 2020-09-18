namespace CommandPattern.Core.Contracts
{
    public interface ICommandInterpreter
    {
        string Read(string inputLine);
    }
}
