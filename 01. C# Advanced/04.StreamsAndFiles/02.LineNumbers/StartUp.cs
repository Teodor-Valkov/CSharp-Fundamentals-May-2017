namespace _02.LineNumbers
{
    using System;
    using System.IO;

    internal class StartUp
    {
        private static void Main()
        {
            StreamReader reader = CreateReader();
            StreamWriter writer = CreateWriter();

            string input = string.Empty;

            int lineNumber = 1;

            using (reader)
            {
                using (writer)
                {
                    while ((input = reader.ReadLine()) != null)
                    {
                        writer.WriteLine($"{lineNumber} {input}");
                        lineNumber++;
                    }
                }
            }

            Console.WriteLine($"{Environment.NewLine}{File.ReadAllText(@"..\..\LineNumbers.txt")}");
        }

        private static StreamReader CreateReader()
        {
            StreamReader reader = null;

            try
            {
                reader = new StreamReader(@"..\..\StartUp.cs");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found!");
            }

            return reader;
        }

        private static StreamWriter CreateWriter()
        {
            StreamWriter writer = null;

            try
            {
                writer = new StreamWriter(@"..\..\LineNumbers.txt");
            }
            catch (IOException)
            {
                Console.WriteLine("Unable to create output file!");
            }

            return writer;
        }
    }
}