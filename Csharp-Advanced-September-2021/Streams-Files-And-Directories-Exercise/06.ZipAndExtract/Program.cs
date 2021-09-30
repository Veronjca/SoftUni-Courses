using System;
using System.IO.Compression;
using System.Text;

namespace _06.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            //ZipFile.CreateFromDirectory(@"C:\VERONICA\zipThat", @"../../../result.zip");

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            StringBuilder fullPath = new StringBuilder(path);
            fullPath.Append(@"\finalResult");

            ZipFile.ExtractToDirectory(@"../../../result.zip", fullPath.ToString());

            
        }
    }
}
