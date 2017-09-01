namespace _04.CopyBinaryFile
{
    using System.IO;

    internal class StartUp
    {
        private const string ImagePath = "../../tiger.jpg";
        private const string DestinationPath = "../../result.jpg";

        private static void Main()
        {
            using (FileStream reader = new FileStream(ImagePath, FileMode.Open))
            {
                using (FileStream writer = new FileStream(DestinationPath, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    int readBytes = 0;

                    while ((readBytes = reader.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        writer.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}