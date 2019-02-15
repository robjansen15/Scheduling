using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule
{
    public class Room
    {
        public int MinLevel { get; set; }
        public int MaxLevel { get; set; }
        public Teachers Teacher { get; set; }

        public int CurrentAllocatedTime { get; set; } // In Minutes
        List<InputEvent> RoomEvents { get; set; }

        public Room(int minLevel, int maxLevel, Teachers teacher)
        {
            this.MinLevel = minLevel;
            this.MaxLevel = maxLevel;
            this.Teacher = teacher;
        }


    }
}
