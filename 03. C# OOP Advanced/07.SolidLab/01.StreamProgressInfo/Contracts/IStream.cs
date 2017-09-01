namespace _01.StreamProgressInfo.Contracts
{
    public interface IStream
    {
        int Length { get; }

        int BytesSent { get; }
    }
}