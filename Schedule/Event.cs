using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule
{
    public class Event
    {
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string ClubId { get; set; }
        public Teachers TeacherName { get; set; }
        public string EventName { get; set; }
        public int ClassLevel { get; set; }
        public string RequiredComposition { get; set; }
        public string RequiredComposer { get; set; }
        public string ChoiceComposition { get; set; }
        public string ChoiceComposer { get; set; }
        public string ChoiceNationality { get; set; }
        public string DuetPartner { get; set; }
        public string PreviousPoints { get; set; }

        public static Event Convert(InputEvent inputEvent)
        {
            return new Event()
            {
                StudentId = inputEvent.StudentId,
                FirstName = inputEvent.FirstName,
                LastName = inputEvent.LastName,
                BirthDate = inputEvent.BirthDate,
                ClubId = inputEvent.ClubId,
                TeacherName = 
            };
        }

        private static Teachers GetTeacher(string teacher)
        {
            switch (teacher)
            {
                case "":
                    return Teachers.Sabitino;
            }
        }
    }
}
