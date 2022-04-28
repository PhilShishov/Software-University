namespace P01.After.Contracts
{
    public interface IStreamable
    {
        int Length { get; }

        int Sent { get; }
    }
}
