﻿namespace FourFlagsRPG.Models.IO
{
    using System.IO;

    public class FileWriter
    {
        public void Write(string content, string directory, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(directory + fileName))
            {
                writer.Write(content);
            }
        }
    }
}