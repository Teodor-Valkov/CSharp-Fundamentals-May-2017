namespace BashSoft.IO
{
    using BashSoft.Contracts;
    using Exceptions;
    using StaticData;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class IOManager : IDirectoryManager
    {
        public void TraverseDirectory(int depth)
        {
            int initialIdentation = SessionData.CurrentPath.Split('\\').Length;

            Queue<string> subFolders = new Queue<string>();
            subFolders.Enqueue(SessionData.CurrentPath);

            while (subFolders.Count != 0)
            {
                string currentPath = subFolders.Dequeue();
                int identation = currentPath.Split('\\').Length - initialIdentation;

                if (depth - identation < 0)
                {
                    break;
                }

                OutputWriter.WriteMessageOnNewLine($"{new string('-', identation)}{currentPath}");

                try
                {
                    foreach (string file in Directory.GetFiles(currentPath))
                    {
                        int indexOfLastSlash = file.LastIndexOf('\\');
                        string fileName = file.Substring(indexOfLastSlash);

                        OutputWriter.WriteMessageOnNewLine(new string('-', indexOfLastSlash) + fileName);
                    }

                    foreach (string directoryPath in Directory.GetDirectories(currentPath))
                    {
                        subFolders.Enqueue(directoryPath);

                        int indexOfLastSlash = directoryPath.LastIndexOf('\\');
                        string directoryName = directoryPath.Substring(indexOfLastSlash);

                        OutputWriter.WriteMessageOnNewLine(new string('-', indexOfLastSlash) + directoryName);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    throw new UnauthorizedAccessException();
                }
            }
        }

        public void CreateDirectoryInCurrentFolder(string currentFolderName)
        {
            string path = Directory.GetCurrentDirectory() + "\\" + currentFolderName;

            try
            {
                Directory.CreateDirectory(path);
            }
            catch (ArgumentException)
            {
                throw new InvalidFileNameException();
            }
        }

        public void ChangeCurrentDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                throw new InvalidPathException();
            }

            SessionData.CurrentPath = absolutePath;
        }

        public void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath == "..")
            {
                try
                {
                    string currentPath = SessionData.CurrentPath;

                    int indexOfLastSlash = currentPath.LastIndexOf('\\');
                    string newPath = currentPath.Substring(0, indexOfLastSlash);

                    SessionData.CurrentPath = newPath;
                }
                catch (ArgumentException)
                {
                    throw new UnableToGoHigherInPartitionHierarchyException();
                }
            }
            else
            {
                string currentPath = SessionData.CurrentPath;
                currentPath += '\\' + relativePath;

                ChangeCurrentDirectoryAbsolute(currentPath);
            }
        }
    }
}