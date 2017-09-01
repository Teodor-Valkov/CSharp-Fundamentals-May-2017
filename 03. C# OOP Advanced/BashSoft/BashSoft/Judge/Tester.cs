namespace BashSoft.Judge
{
    using BashSoft.Contracts;
    using BashSoft.Exceptions;
    using IO;
    using StaticData;
    using System;
    using System.IO;

    public class Tester : IContentComparer
    {
        public void CompareContent(string actualOutputPath, string expectedOutputPath)
        {
            try
            {
                OutputWriter.WriteMessageOnNewLine("Reading files...");
                string mismatchesPath = GetMismatchPath(expectedOutputPath);

                string[] actualOutputLines = File.ReadAllLines(actualOutputPath);
                string[] expectedOutpultLines = File.ReadAllLines(expectedOutputPath);

                bool hasMismatch;
                string[] mismatches = GetLinesWithPossibleMismatches(actualOutputLines, expectedOutpultLines, out hasMismatch);

                this.PrintOutput(mismatchesPath, hasMismatch, mismatches);
                OutputWriter.WriteMessageOnNewLine("Files read!");
            }
            catch (IOException)
            {
                throw new InvalidPathException();
            }
        }

        private string GetMismatchPath(string expectedOutputPath)
        {
            int index = expectedOutputPath.LastIndexOf('\\');

            string directoryPath = string.Empty;
            if (index != -1)
            {
                directoryPath = expectedOutputPath.Substring(0, index);
            }

            string finalPath = directoryPath + "\\Mismatches.txt";
            return finalPath;
        }

        private string[] GetLinesWithPossibleMismatches(string[] actualOutputLines, string[] expectedOutpultLines, out bool hasMismatch)
        {
            hasMismatch = false;
            string output = string.Empty;

            OutputWriter.WriteMessageOnNewLine("Comparing files..." + Environment.NewLine);

            int minOutputLinesCount = actualOutputLines.Length;

            if (actualOutputLines.Length != expectedOutpultLines.Length)
            {
                hasMismatch = true;
                minOutputLinesCount = Math.Min(actualOutputLines.Length, expectedOutpultLines.Length);
                OutputWriter.DisplayException(ExceptionMessages.ComparisonOfFilesWithDifferentSizes + Environment.NewLine);
            }

            string[] mismatches = new string[minOutputLinesCount];

            for (int i = 0; i < minOutputLinesCount; i++)
            {
                string actualLine = actualOutputLines[i];
                string expectedLine = expectedOutpultLines[i];

                if (!actualLine.Equals(expectedLine))
                {
                    output = $"Mismatch at line {i} -- expected: \"{expectedLine}\", actual: \"{expectedLine}\"";
                    output += Environment.NewLine;
                    hasMismatch = true;
                }
                else
                {
                    output = actualLine;
                    output += Environment.NewLine;
                }

                mismatches[i] = output;
            }

            return mismatches;
        }

        private void PrintOutput(string mismatchesPath, bool hasMismatch, string[] mismatches)
        {
            if (hasMismatch)
            {
                foreach (string line in mismatches)
                {
                    OutputWriter.WriteMessageOnNewLine(line);
                }

                File.WriteAllLines(mismatchesPath, mismatches);
                return;
            }

            OutputWriter.WriteMessageOnNewLine("Files are identical! There are no mismatches!");
        }
    }
}