using System;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            Random rand = new Random();
            byte[] byteArray = new byte[256];
            rand.NextBytes(byteArray);

            WriteBytesToFile(byteArray, "test.txt");

            ReadBytesFromFile("test.txt");
        }

        public static void WriteBytesToFile(byte[] byteArray, string filePath)
        {
            FileStream fout = null;
            try
            {
                fout = new FileStream(filePath, FileMode.Create);
                fout.Write(byteArray, 0, byteArray.Length);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Input/Output problem: " + ex.Message);
            }
            finally
            {
                if (fout != null) fout.Close();
            }
        }

        public static void ReadBytesFromFile(string filePath)
        {

            int b;
            FileStream fin = null;
            try
            {
                fin = new FileStream(filePath, FileMode.Open);

                do
                {
                    b = fin.ReadByte();
                    if (b != -1) Console.Write(b);
                } while (b != -1);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Input/Output problem: " + ex.Message);
            }
            finally
            {
                if (fin != null) fin.Close();
            }
        }
    }
}
