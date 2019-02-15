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
        private List<Room> Rooms = new List<Room>
        {
            new Room(0, 0, 10, Teachers.Unknown3, new List<EventType>{ EventType.PIANO, EventType.NON_PIANO, EventType.LYNN_FREEMAN_OLSON, EventType.PIANO_SIGHT_READING }),
            new Room(1, 11, 20, Teachers.Lewis, new List<EventType>{ EventType.PIANO, EventType.NON_PIANO, EventType.LYNN_FREEMAN_OLSON, EventType.PIANO_SIGHT_READING }),
            new Room(2, 0, 10, Teachers.Unknown2, new List<EventType>{ EventType.PIANO, EventType.NON_PIANO, EventType.LYNN_FREEMAN_OLSON, EventType.PIANO_SIGHT_READING }),
            new Room(3, 0, 10, Teachers.Unknown1, new List<EventType>{ EventType.PIANO, EventType.NON_PIANO, EventType.LYNN_FREEMAN_OLSON, EventType.PIANO_SIGHT_READING }),
            new Room(4, 0, 10, Teachers.Godfrey, new List<EventType>{ EventType.PIANO, EventType.NON_PIANO, EventType.LYNN_FREEMAN_OLSON, EventType.PIANO_SIGHT_READING}),
            new Room(5, 0, 20, Teachers.Sabatino, new List<EventType>{ EventType.PIANO, EventType.NON_PIANO, EventType.LYNN_FREEMAN_OLSON, EventType.PIANO_SIGHT_READING }),
            new Room(6, 0, 10, Teachers.Sidwell, new List<EventType>{ EventType.PIANO, EventType.NON_PIANO, EventType.LYNN_FREEMAN_OLSON, EventType.PIANO_SIGHT_READING }),
            new Room(7, 0, 20, Teachers.Scott, new List<EventType>{ EventType.PIANO, EventType.NON_PIANO, EventType.LYNN_FREEMAN_OLSON, EventType.PIANO_SIGHT_READING }),
            new Room(8, 0, 10, Teachers.Unknown4, new List<EventType>{ EventType.PIANO, EventType.NON_PIANO, EventType.LYNN_FREEMAN_OLSON, EventType.PIANO_SIGHT_READING }),
        };

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
            events = events.Randomize().ToList();

            foreach(var evnt in events.FindAll(x => x.TypeOfEvent == EventType.LYNN_FREEMAN_OLSON))
            {
                List<Room> applicableRooms = Rooms.FindAll(x => x.CanAssignRoom(evnt));

                if (applicableRooms.Any())
                {
                    Room room = applicableRooms.OrderBy(i => i.CurrentAllocatedTime).FirstOrDefault();
                    Rooms.FirstOrDefault(x => x.RoomId == room.RoomId).AssignRoom(evnt);
                }
                else
                {
                    throw new ArgumentException("Could not match event to an judge.");
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
                else
                {
                    throw new ArgumentException("Could not match event to an judge.");
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
                else
                {
                    throw new ArgumentException("Could not match event to an judge.");
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
                else
                {
                    throw new ArgumentException("Could not match event to an judge.");
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
