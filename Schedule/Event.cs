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
        public string TypeOfEvent { get; set; }
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
                TeacherName = GetTeacher(inputEvent.TeacherName),
                TypeOfEvent = inputEvent.TypeOfEvent,
                ClassLevel = Levels.GetLevel(inputEvent.ClassLevel),
                RequiredComposition = inputEvent.RequiredComposition,
                RequiredComposer = inputEvent.RequiredComposer,
                ChoiceComposition = inputEvent.ChoiceComposition,
                ChoiceComposer = inputEvent.ChoiceComposer,
                ChoiceNationality = inputEvent.ChoiceNationality,
                DuetPartner = inputEvent.DuetPartner,
                PreviousPoints = inputEvent.PreviousPoints
            };
        }

        private static Teachers GetTeacher(string teacher)
        {
            switch (teacher)
            {
                case "MARK SABATINO":
                    return Teachers.Sabatino;
                case "LINDA SABATINO":
                    return Teachers.Sabatino;
                case "SARAH SABATINO":
                    return Teachers.Sabatino;
                case "LINDA SIDWELL":
                    return Teachers.Sidwell;
                case "CHERYL SCOTT":
                    return Teachers.Scott;
                case "SHARON LEWIS":
                    return Teachers.Lewis;
                default:
                    return Teachers.UNKNOWN;
            }

            return Teachers.UNKNOWN;
        }

        private static EventType GetEventType(string eventName)
        {
            switch (eventName)
            {
                case "LYNN FREEMAN OLSON":
                    return EventType.LYNN_FREEMAN_OLSON;
                case "PIANO SIGHTREADING":
                    return EventType.PIANO_SIGHT_READING;
                case "SAXOPHONE SOLO":
                    return EventType.NON_PIANO;
                case "GUITAR SIGHTREADING CLASSICAL":
                    return EventType.NON_PIANO;
                case "VIOLIN PATRIOTIC AND FOLK":
                    return EventType.NON_PIANO;
                case "TROMBONE SOLO":
                    return EventType.NON_PIANO;
                case "FLUTE PATRIOTIC AND FOLK:
                    return EventType.NON_PIANO;
                case "SOPRANO RECORDER SOLO":
                    return EventType.NON_PIANO;
                case "FLUTE SOLO":
                    return EventType.NON_PIANO;
                case "TRUMPET SOLO":
                    return EventType.NON_PIANO;
                case "CLARINET SIGHTREADING":
                    return EventType.NON_PIANO;
                case "GUITAR PATRIOTIC AND FOLK":
                    return EventType.NON_PIANO;
                case "SAXOPHONE SIGHTREADING":
                    return EventType.NON_PIANO;
                case "SOPRANO RECORDER PATRIOTIC AND FOLK":
                    return EventType.NON_PIANO;
                case "GUITAR SOLO":
                    return EventType.NON_PIANO;
                case "BASSOON SOLO":
                    return EventType.NON_PIANO;
                case "CLARINET PATRIOTIC AND FOLK":
                    return EventType.NON_PIANO;
                case "VIOLIN SOLO":
                    return EventType.NON_PIANO;
                case "TRUMPET SIGHTREADING":
                    return EventType.NON_PIANO;
                case "TRUMPET PATRIOTIC AND FOLK":
                    return EventType.NON_PIANO;
                case "CLARINET SOLO":
                    return EventType.NON_PIANO;
                case "SAXOPHONE PATRIOTIC AND FOLK":
                    return EventType.NON_PIANO;
                case "SOPRANO RECORDER SIGHTREADING?":
                    return EventType.NON_PIANO;
                default:
                    return EventType.PIANO;

            }

            return EventType.UNKNOWN;
        }
    }
}
