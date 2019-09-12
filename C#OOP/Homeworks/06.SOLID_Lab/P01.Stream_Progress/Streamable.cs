namespace P01.Stream_Progress
{
    using P01.Stream_Progress.Contracts;

    public class Streamable : IStreamable
    {
        public Streamable(int length, int bytesSent)
        {
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public int Length { get ; set ; }

        public int BytesSent { get ; set ; }
    }
}
