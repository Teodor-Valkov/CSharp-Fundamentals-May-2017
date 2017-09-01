namespace _01.OddLines
{
    using System;
    using System.IO;

    internal class StartUp
    {
        private static void Main()
        {
            try
            {
                StreamReader reader = new StreamReader(@"..\..\StartUp.cs");

                string input = string.Empty;

                int lineNumber = 0;

                using (reader)
                {
                    while ((input = reader.ReadLine()) != null)
                    {
                        if (lineNumber % 2 == 1)
                        {
                            Console.WriteLine($"Line {lineNumber,2}: {input}");
                        }

                        lineNumber++;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found!");
            }
        }
    }
}