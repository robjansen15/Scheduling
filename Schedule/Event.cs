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
        public EventType TypeOfEvent { get; set; }
        public int ClassLevel { get; set; }
        public string RequiredComposition { get; set; }
        public string RequiredComposer { get; set; }
        public string ChoiceComposition { get; set; }
        public string ChoiceComposer { get; set; }
        public string ChoiceNationality { get; set; }
        public string DuetPartner { get; set; }
        public string PreviousPoints { get; set; }
        public int Time { get; set; }

        public static List<Event> Convert(List<InputEvent> inputEvents)
        {
            var events = new List<Event>();
            inputEvents.ForEach(inputEvent => events.Add(Convert(inputEvent)));
            return events;
        }

        private static Event Convert(InputEvent inputEvent)
        {
            return new Event()
            {
                StudentId = inputEvent.StudentId,
                FirstName = inputEvent.FirstName,
                LastName = inputEvent.LastName,
                BirthDate = inputEvent.BirthDate,
                ClubId = inputEvent.ClubId,
                TeacherName = GetTeacher(inputEvent.TeacherName),
                TypeOfEvent = GetEventType(inputEvent.TypeOfEvent),
                ClassLevel = Levels.GetLevel(inputEvent.ClassLevel),
                RequiredComposition = inputEvent.RequiredComposition,
                RequiredComposer = inputEvent.RequiredComposer,
                ChoiceComposition = inputEvent.ChoiceComposition,
                ChoiceComposer = inputEvent.ChoiceComposer,
                ChoiceNationality = inputEvent.ChoiceNationality,
                DuetPartner = inputEvent.DuetPartner,
                PreviousPoints = inputEvent.PreviousPoints,
                Time = Levels.GetLevel(inputEvent.ClassLevel) > 10 ? 7 : 5
            };
        }

        private static Teachers GetTeacher(string teacher)
        {
            switch (teacher)
            {
                case "MARK SABITINO":
                    return Teachers.Sabitino;
            }

            return Teachers.UNKNOWN;
        }

        private static EventType GetEventType(string eventName)
        {
            switch (eventName)
            {
                case "":
                    return EventType.LYNN_FREEMAN_OLSON;
            }

            return EventType.UNKNOWN;
        }
    }
}
