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

        public Core(string inputFile)
        {
            this.InputFile = inputFile;
        }

        public void Run()
        {
            var events = GetEvents();
            //READ CSV

            //RANDOMIZE DATA
           
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
    }
}
