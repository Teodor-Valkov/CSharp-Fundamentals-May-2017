namespace _01.RecyclingStation.Contracts.IO
{
    public interface IWriter
    {
        void WriteLine(string output);

        void WriteAllLines();
    }
}