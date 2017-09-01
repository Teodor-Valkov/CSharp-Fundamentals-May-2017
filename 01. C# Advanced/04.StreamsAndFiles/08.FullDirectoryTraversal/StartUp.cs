namespace _08.FullDirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    internal class StartUp
    {
        private static List<string> filesAsStrings = new List<string>();

        private static void Main()
        {
            filesAsStrings = TraverseDirectory(@"../../");

            List<FileInfo> files = filesAsStrings.Select(file => new FileInfo(file)).ToList();

            // Sorting the list with File Info of all files
            //
            var groupedFilesByExtension = files
                .OrderBy(file => file.Length)
                .GroupBy(file => file.Extension)
                .OrderByDescending(group => group.Count())
                .ThenBy(group => group.Key);

            // Find desktop path
            //
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Create 'report-recursive.txt' file
            //
            using (StreamWriter writer = new StreamWriter(desktop + "/report-recursive-with-method.txt"))
            {
                foreach (var group in groupedFilesByExtension)
                {
                    writer.WriteLine(group.Key);

                    foreach (FileInfo item in group)
                    {
                        writer.WriteLine($"--{item.Name} - {item.Length / 1024.0:F3}kb");
                    }
                }
            }

            Console.WriteLine("Check your desktop:");
            Console.WriteLine($"There should be 'report-recursive-with-method.txt' file containing all the files from project solution directory!{Environment.NewLine}");
        }

        private static List<string> TraverseDirectory(string directory)
        {
            // Get all files in current directory
            //
            string[] allFiles = Directory.GetFiles(directory);
            foreach (string file in allFiles)
            {
                filesAsStrings.Add(file);
            }

            // Get all subdirectories in current directory
            //
            string[] subDirectories = Directory.GetDirectories(directory);
            foreach (string subDirectory in subDirectories)
            {
                // Get all files and subdirectories in current subdirectory
                //
                TraverseDirectory(subDirectory);
            }

            return filesAsStrings;
        }
    }
}