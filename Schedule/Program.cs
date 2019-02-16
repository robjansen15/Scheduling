using System;

namespace Schedule
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\terrabyte\Downloads\piano_fest.csv";
            string outPath = @"C:\Users\terrabyte\Downloads\";
            Core core = new Core(path, outPath);
            core.Run();
        }
    }
}
