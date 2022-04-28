namespace P01.After
{
    using Contracts;

    public  class Music : IStreamable
    {
        public int Length { get; set; }

        public int Sent { get; set; }

        public string Artist { get; set; }

        public string Album { get; set; }
    }
}
