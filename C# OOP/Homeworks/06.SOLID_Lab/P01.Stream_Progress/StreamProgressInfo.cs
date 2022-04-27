
namespace P01.Stream_Progress
{
    using P01.Stream_Progress.Contracts;
    
    public class StreamProgressInfo
    {
        private readonly IStreamable streamable;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(IStreamable streamable)
        {
            this.streamable = streamable;
        }

        public int CalculateCurrentPercent()
        {
            return (this.streamable.BytesSent * 100) / this.streamable.Length;
        }
    }
}
