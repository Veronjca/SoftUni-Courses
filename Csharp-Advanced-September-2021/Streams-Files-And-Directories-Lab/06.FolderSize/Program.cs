using System;
using System.IO;

namespace _06.FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fileNames = Directory.GetFiles("TestFolder");


            long size = 0;
            foreach (var item in fileNames)
            {
           
                FileStream stream = new FileStream(item, FileMode.Open);
                size += stream.Length;
            }

            Console.WriteLine((decimal)size / 1024 / 1024);
        }
    }
}
