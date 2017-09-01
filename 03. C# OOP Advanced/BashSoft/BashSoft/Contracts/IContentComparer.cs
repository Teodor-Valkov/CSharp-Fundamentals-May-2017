namespace BashSoft.Contracts
{
    public interface IContentComparer
    {
        void CompareContent(string actualOutputPath, string expectedOutputPath);
    }
}