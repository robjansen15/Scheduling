﻿using System;

namespace Schedule
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\Downloads\piano_fest.csv";
            Core core = new Core(path);
            core.Run();
        }
    }
}
