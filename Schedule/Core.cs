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

            foreach(var evnt in events)
            {
                List<Room> applicableRooms = Rooms.FindAll(x => x.CanAssignRoom(evnt));

                if (applicableRooms.Any())
                {
                    Room room = applicableRooms.OrderBy(i => i.CurrentAllocatedTime).FirstOrDefault();
                    Rooms.FirstOrDefault(x => x.RoomId == room.RoomId).AssignRoom(evnt);
                }
                else
                {
                    //*SHOULD NEVER GET HERE*
                    throw new ArgumentException("No applicable rooms");
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
