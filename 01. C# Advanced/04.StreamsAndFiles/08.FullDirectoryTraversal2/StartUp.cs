namespace _08.FullDirectoryTraversal2
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            // Get all file names in the current directory
            //
            string[] filePaths = Directory.GetFiles(@"../../", "*.*", SearchOption.AllDirectories);

            List<FileInfo> files = filePaths.Select(file => new FileInfo(file)).ToList();

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

            // Create 'report.txt' file
            //
            using (StreamWriter writer = new StreamWriter(desktop + "/report-recursive.txt"))
            {
                foreach (IGrouping<string, FileInfo> group in groupedFilesByExtension)
                {
                    writer.WriteLine(group.Key);

                    foreach (FileInfo item in group)
                    {
                        writer.WriteLine($"--{item.Name} - {item.Length / 1024.0:F3}kb");
                    }
                }
            }

            Console.WriteLine("Check your desktop:");
            Console.WriteLine($"There should be 'report-recursive.txt' file, containing all the files (grouped and ordered) from project solution directory!{Environment.NewLine}");
        }
    }
}