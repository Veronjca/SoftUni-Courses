using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using FileStream stream = new FileStream("copyMe.png", FileMode.Open);
            using FileStream writer = new FileStream("output.png", FileMode.OpenOrCreate);

            byte[] buffer = new byte[256];

            while (true)
            {
                int bytesRead = stream.Read(buffer);
                if (bytesRead == 0)
                {
                    break;
                }

                writer.Write(buffer);
            }
        }
    }
}
