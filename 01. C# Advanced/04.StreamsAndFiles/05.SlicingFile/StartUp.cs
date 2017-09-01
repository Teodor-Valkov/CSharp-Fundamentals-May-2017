namespace _05.SlicingFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class StartUp
    {
        private static List<string> files = new List<string>();

        // The solution works with created file 'input.txt' - from the original file we get 5 other parts like in the example from the exercises
        //
        // For solution with a file with different extension - you have to change the source file in the project solution, the 'string sourceFile',
        // the 'string currentPartFileName' and the 'string assemledFile' with their hardcoded extensions (now they are '.txt')
        //
        private static void Main()
        {
            string sourceFile = @"../../input.txt";
            string destinationDirectory = @"../../";
            int numberOfParts = 5;

            Slice(sourceFile, destinationDirectory, numberOfParts);

            Assemble(files, destinationDirectory);

            Console.WriteLine($"Check the project directory:{Environment.NewLine}");
            Console.WriteLine("*** 5 parts were created from the source file - 'input.txt'!");
            Console.WriteLine($"*** 1 assembled file was created from the 5 parts!{Environment.NewLine}");
        }

        private static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                long partSize = (long)Math.Ceiling((double)reader.Length / parts);
                long remainingSize = reader.Length;

                for (int i = 0; i < parts; i++)
                {
                    string currentPartFileName = $"{destinationDirectory}Part-{i}.txt";
                    files.Add(currentPartFileName);

                    // Reading one part
                    //
                    using (FileStream writer = new FileStream(currentPartFileName, FileMode.Create))
                    {
                        byte[] buffer = new byte[4096];
                        long currentPartSize = 0;

                        while (currentPartSize < partSize)
                        {
                            int readBytes = reader.Read(buffer, 0, buffer.Length);

                            if (readBytes == 0)
                            {
                                break;
                            }

                            // Writing one part
                            //
                            writer.Write(buffer, 0, readBytes);
                            currentPartSize += readBytes;
                        }
                    }

                    // Checking if the remaining size which still has to be read is less then the calculated part size
                    //
                    remainingSize = (int)reader.Length - (i * partSize);

                    if (remainingSize < partSize)
                    {
                        partSize = remainingSize;
                    }
                }
            }
        }

        private static void Assemble(List<string> files, string destinationDirectory)
        {
            // Creating the file path for the assembled file
            //
            string assemledFile = $"{destinationDirectory}assembled.txt";
            FileStream writer = new FileStream(assemledFile, FileMode.Create);
            writer.Close();

            using (writer = new FileStream(assemledFile, FileMode.Append))
            {
                // Reading the destinations of the parts from the 'files' list
                //
                foreach (string filePart in files)
                {
                    using (FileStream reader = new FileStream(filePart, FileMode.Open))
                    {
                        // Create a byte array from the content of the current file
                        //
                        byte[] buffer = new byte[4096];

                        while (true)
                        {
                            int readBytes = reader.Read(buffer, 0, buffer.Length);

                            if (readBytes == 0)
                            {
                                break;
                            }

                            // Write the bytes to the assembled file
                            writer.Write(buffer, 0, readBytes);
                        }
                    }
                }
            }
        }
    }
}