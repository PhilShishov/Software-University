namespace P01.After
{
    using Contracts;
    public class Progress
    {
        private readonly IStreamable result;

        public Progress(IStreamable result)
        {
            this.result = result;
        }

        public int CurrentPercent()
        {
            return this.result.Sent * 100 / this.result.Length;
        }
    }
}
