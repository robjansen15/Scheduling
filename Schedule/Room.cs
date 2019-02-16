using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule
{
    public class Room
    {
        public int RoomId { get; set; }
        public int MinLevel { get; set; }
        public int MaxLevel { get; set; }
        public Teachers Teacher { get; set; }
        public List<EventType> SupportedEventTypes { get; set; }
        public int RoomBuffer { get; set; } = 0;

        public int CurrentAllocatedTime { get; set; } // In Minutes
        List<Event> RoomEvents { get; set; }

        public Room(int roomId, int minLevel, int maxLevel, Teachers teacher, List<EventType> supportedEventTypes)
        {
            this.RoomId = roomId;
            this.MinLevel = minLevel;
            this.MaxLevel = maxLevel;
            this.Teacher = teacher;
            this.SupportedEventTypes = supportedEventTypes;
            RoomEvents = new List<Event>();
        }

        public void AssignRoom(Event evnt)
        {
            CurrentAllocatedTime += evnt.Time;
            RoomEvents.Add(evnt);
        }

        public bool CanAssignRoom(Event evnt)
        {
            if (this.Teacher == evnt.TeacherName)
                return false;

            if (this.MaxLevel < evnt.ClassLevel)
                return false;

            if (this.MinLevel - RoomBuffer > evnt.ClassLevel)
                return false;

            if (!this.SupportedEventTypes.Contains(evnt.TypeOfEvent))
                return false;

            return true;
        }

    }
}
