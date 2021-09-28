using System;
using System.IO;
using System.Linq;

namespace _05.SliceFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using FileStream stream = new FileStream("sliceMe.txt", FileMode.Open);

            byte[]  data = new byte[stream.Length];
            stream.Read(data);

            int sizePerFile = (int)Math.Ceiling(stream.Length / 4.0);
            for (int i = 1; i <= 4; i++)
            {
                byte[] buffer = new byte[sizePerFile];
                stream.Read(buffer);

                stream.Read(buffer);

                using FileStream writer = new FileStream($"Part-{i}.txt", FileMode.OpenOrCreate);
                writer.Write(buffer);
            }
            
        }
    }
}
