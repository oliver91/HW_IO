using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace IO_Task3
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Choose file Path:");
            string filePath = Console.ReadLine();
            Console.WriteLine("Choose compressed file Path: ");
            string compFilePath = Console.ReadLine();

            Copy(filePath, compFilePath);
        }

        public static void Copy(string filePath, string compFilePath)
        {
            string content = File.ReadAllText(filePath);
            byte[] bytes = Encoding.UTF8.GetBytes(content);
            byte[] compressedContent = Compress(bytes);
            File.WriteAllBytes(compFilePath, compressedContent);
        }

        public static byte[] Compress(byte[] raw)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                using (GZipStream gzip = new GZipStream(memory,
                CompressionMode.Compress, true))
                {
                    gzip.Write(raw, 0, raw.Length);
                }
                return memory.ToArray();
            }
        }
    }
}
