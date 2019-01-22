using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tales
{
    public static class FileReader
    {
        public static List<string> ReadAllFromDirectory(string path)
        {
            List<string> files = new List<string>();
            foreach (string file in Directory.EnumerateFiles(path, "*.md"))
            {
                if (!file.Contains("template"))
                {
                    files.Add(file);
                }

            }

            return files;
        }
    }
}
