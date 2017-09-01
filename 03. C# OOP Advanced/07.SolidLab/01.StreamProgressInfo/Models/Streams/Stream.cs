namespace _01.StreamProgressInfo.Models.Streams
{
    using Contracts;

    public abstract class Stream : IStream
    {
        protected Stream(int length, int bytesSent)
        {
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public int Length { get; private set; }

        public int BytesSent { get; private set; }
    }
}