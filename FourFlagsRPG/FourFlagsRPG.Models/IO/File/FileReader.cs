namespace FourFlagsRPG.Models.IO
{
    using System.IO;

    public class FileReader
    {
        public string ReadToEnd(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }
    }
}