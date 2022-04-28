namespace P01.After
{
    using Contracts;

    public class File : IStreamable
    {
        public string Name { get; set; }

        public int Length { get; set; }

        public int Sent { get; set; }
    }
}
