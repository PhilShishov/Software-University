namespace P01.Before
{
    public class Progress
    {
        private readonly File file;

        public Progress(File file)
        {
            this.file = file;
        }

        public int CurrentPercent()
        {
            return this.file.Sent * 100 / this.file.Length;
        }
    }
}
