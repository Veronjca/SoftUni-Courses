using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _05.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles(@"C:\VERONICA\Riot Games\Riot Client", ".");

            var info = new Dictionary<string, Dictionary<string, decimal>>();

            for (int i = 0; i < files.Length; i++)
            {
                FileInfo currentFile = new FileInfo(files[i]);

                string fileExtension = currentFile.Extension;
                string name = currentFile.Name;
                long size = currentFile.Length;
                decimal sizeInKb = size * 0.0009765625M;

                if (!info.ContainsKey(fileExtension))
                {
                    info.Add(fileExtension, new Dictionary<string, decimal>());                   
                }

                info[fileExtension].Add(name, sizeInKb);
            }

            StringBuilder fullPath = new StringBuilder();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            fullPath.Append(path);
            fullPath.Append(@"\report.txt");

            using StreamWriter writer = new StreamWriter(fullPath.ToString());

            foreach (var item in info.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                writer.WriteLine(item.Key);

                foreach (var file in item.Value.OrderBy(x => x.Value))
                {
                    writer.WriteLine($"--{file.Key} - {file.Value:f3}kb");
                }
            }
        }
    }
}
