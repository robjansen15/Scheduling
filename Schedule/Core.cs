using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Schedule
{
    public class Core
    {
        private string InputFile { get; set; }
        private List<Room> Rooms { get; set; }

        public Core(string inputFile)
        {
            this.InputFile = inputFile;
        }

        public void Run()
        {
            //Read CSV
            var inputEvents = GetEvents();
            //Convert the events
            var events = Event.Convert(inputEvents);
            //Randomize data


            foreach(var evnt in events.FindAll(x => x.TypeOfEvent == EventType.LYNN_FREEMAN_OLSON))
            {
                List<Room> applicableRooms = Rooms.FindAll(x => x.CanAssignRoom(evnt));

                if (applicableRooms.Any())
                {
                    Room room = applicableRooms.OrderBy(i => i.CurrentAllocatedTime).FirstOrDefault();
                    Rooms.FirstOrDefault(x => x.RoomId == room.RoomId).AssignRoom(evnt);
                }
            }

            foreach (var evnt in events.FindAll(x => x.TypeOfEvent == EventType.NON_PIANO))
            {
                List<Room> applicableRooms = Rooms.FindAll(x => x.CanAssignRoom(evnt));

                if (applicableRooms.Any())
                {
                    Room room = applicableRooms.OrderBy(i => i.CurrentAllocatedTime).FirstOrDefault();
                    Rooms.FirstOrDefault(x => x.RoomId == room.RoomId).AssignRoom(evnt);
                }
            }

            foreach (var evnt in events.FindAll(x => x.TypeOfEvent == EventType.PIANO_SIGHT_READING))
            {
                List<Room> applicableRooms = Rooms.FindAll(x => x.CanAssignRoom(evnt));

                if (applicableRooms.Any())
                {
                    Room room = applicableRooms.OrderBy(i => i.CurrentAllocatedTime).FirstOrDefault();
                    Rooms.FirstOrDefault(x => x.RoomId == room.RoomId).AssignRoom(evnt);
                }
            }

            foreach (var evnt in events.FindAll(x => x.TypeOfEvent == EventType.PIANO))
            {
                List<Room> applicableRooms = Rooms.FindAll(x => x.CanAssignRoom(evnt));

                if (applicableRooms.Any())
                {
                    Room room = applicableRooms.OrderBy(i => i.CurrentAllocatedTime).FirstOrDefault();
                    Rooms.FirstOrDefault(x => x.RoomId == room.RoomId).AssignRoom(evnt);
                }
            }

        }

        private List<InputEvent> GetEvents()
        {
            List<InputEvent> events = new List<InputEvent>();
            using (var reader = new StreamReader(InputFile))
            using (var csv = new CsvReader(reader))
            {
                events = csv.GetRecords<InputEvent>().ToList();
            }

            return events;
        }

        private void ReorderRooms()
        {
            Rooms = Rooms.OrderBy(x => x.CurrentAllocatedTime).ToList();
        }
    }
}
