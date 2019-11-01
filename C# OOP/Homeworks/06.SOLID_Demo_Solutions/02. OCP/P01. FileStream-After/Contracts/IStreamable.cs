namespace P01._FileStream_After.Contracts
{
    public interface IStreamable
    {
        int Length { get; }

        int Sent { get; }
    }
}
