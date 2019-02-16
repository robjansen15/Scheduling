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
        private string OutputFile { get; set; }

        private List<Room> Rooms = new List<Room>
        {
            new Room(0, 0, 10, Teachers.Unknown3, new List<EventType>{ EventType.PIANO, EventType.PIANO_SIGHT_READING }),
            new Room(1, 11, 20, Teachers.Lewis, new List<EventType>{ EventType.PIANO, EventType.PIANO_SIGHT_READING }),
            new Room(2, 0, 10, Teachers.Scott, new List<EventType>{ EventType.PIANO }),
            new Room(3, 0, 10, Teachers.Unknown1, new List<EventType>{ EventType.PIANO }),
            new Room(4, 0, 20, Teachers.Godfrey, new List<EventType>{ EventType.PIANO, EventType.PIANO_SIGHT_READING, EventType.NON_PIANO }),
            new Room(5, 0, 10, Teachers.Sabatino, new List<EventType>{ EventType.PIANO }),
            new Room(6, 0, 10, Teachers.Sidwell, new List<EventType>{ EventType.PIANO, EventType.LYNN_FREEMAN_OLSON })         
        };

        public Core(string inputFile, string outputFile)
        {
            this.InputFile = inputFile;
            this.OutputFile = outputFile;
        }

        public void Run()
        {
            //Read CSV
            var inputEvents = GetEvents();
            //Convert the events
            var events = Event.Convert(inputEvents);
            //Randomize data
            events = events.Randomize().ToList();

            HandleRoomAssignments(events);

            foreach(var room in Rooms)
            {
                var path = OutputFile + "-" + room.Teacher.ToString();
                WriteRoomToFile(room, path);
            }
        }

        private void HandleRoomAssignments(List<Event> events)
        {
            foreach (var evnt in events.FindAll(x => x.TypeOfEvent == EventType.LYNN_FREEMAN_OLSON))
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
                for (int i = 0; i < Rooms.Count; i++)
                {
                    Rooms[i].RoomBuffer = 3;
                }

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
                for (int i = 0; i < Rooms.Count; i++)
                {
                    Rooms[i].RoomBuffer = 5;
                }

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

        private void WriteRoomToFile(Room room, string path)
        {
            string data = WriteToString(room);
            File.WriteAllText(path + ".txt", data);
        }

        private string WriteToString(Room room)
        {
            string result = string.Empty;
            using (var mem = new MemoryStream())
            using (var writer = new StreamWriter(mem))
            using (var csvWriter = new CsvWriter(writer))
            {
                csvWriter.Configuration.Delimiter = ",";
                csvWriter.Configuration.HasHeaderRecord = true;
                csvWriter.Configuration.AutoMap<Event>();

                csvWriter.WriteHeader<Event>();
                csvWriter.WriteRecords(room.RoomEvents);

                writer.Flush();
                result = Encoding.UTF8.GetString(mem.ToArray());               
            }

            return result;
        }

        private void ReorderRooms()
        {
            Rooms = Rooms.OrderBy(x => x.CurrentAllocatedTime).ToList();
        }

    }
}
