namespace P01._FileStream_After
{
    using Contracts;

    public class File : IStreamable
    {
        public string Name { get; set; }

        public int Length { get; set; }

        public int Sent { get; set; }
    }
}
