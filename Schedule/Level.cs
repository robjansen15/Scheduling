using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule
{
    public class Level
    {
        public string Name { get; set; }
        public int Lvl { get; set; }

        public Level(string name, int level)
        {
            this.Name = name;
            this.Lvl = level;
        }
    }
}
