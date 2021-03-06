﻿namespace _06.ZippingSlicedFiles2
{
    using System.IO;
    using System.IO.Compression;

    internal class StartUp
    {
        private static void Main()
        {
            int numberOfParts = 5;

            Slice("../../input.txt", numberOfParts);
            Assemble("../../assembled.txt", numberOfParts);
        }

        private static void Slice(string filePath, int numberOfParts)
        {
            FileStream input = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);

            long remainder = input.Length % numberOfParts;
            long partBytes = input.Length / numberOfParts;

            for (int i = 0; i < numberOfParts; i++)
            {
                string fileName = $"part-{i + 1}" + ".gz";
                FileStream output = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);

                GZipStream compressedOutput = new GZipStream(output, CompressionMode.Compress);

                byte[] buffer = new byte[partBytes];

                if (i == 0)
                {
                    buffer = new byte[partBytes + remainder];
                }

                input.Read(buffer, 0, buffer.Length);
                compressedOutput.Write(buffer, 0, buffer.Length);

                output.Close();
            }

            input.Close();
        }

        private static void Assemble(string outputFilePath, int numberOfParts)
        {
            FileStream outputFile = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write);

            for (int i = 0; i < numberOfParts; i++)
            {
                FileStream currentFile = new FileStream($"part-{i + 1}.gz", FileMode.Open, FileAccess.Read);
                GZipStream decompressedOutput = new GZipStream(currentFile, CompressionMode.Decompress);

                byte[] buffer = new byte[currentFile.Length];
                decompressedOutput.Read(buffer, 0, buffer.Length);
                outputFile.Write(buffer, 0, buffer.Length);
            }
        }
    }
}