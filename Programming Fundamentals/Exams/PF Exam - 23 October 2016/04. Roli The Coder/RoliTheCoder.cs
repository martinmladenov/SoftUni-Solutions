namespace _04.Roli_The_Coder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RoliTheCoder
    {
        public static void Main()
        {
            var events = new List<Event>();
            string input;
            while ((input = Console.ReadLine()) != "Time for Code")
            {
                var split = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (split.Length < 2) continue;
                if (!int.TryParse(split[0], out int id)) continue;
                if (split[1].Length < 2 || split[1][0] != '#') continue;
                string name = split[1].Substring(1);
                var participants = split.Skip(2).ToList();
                if (events.Any(ev => ev.Id == id && ev.Name != name)) continue;
                foreach (var ev in events)
                {
                    if (ev.Id != id) continue;
                    events.Remove(ev);
                    participants.AddRange(ev.Participants);
                    break;
                }
                participants = participants.Distinct().ToList();
                events.Add(new Event(id, name, participants));
            }
            foreach (var ev in events.OrderByDescending(ev => ev.Participants.Count).ThenBy(ev => ev.Name))
            {
                Console.WriteLine($"{ev.Name} - {ev.Participants.Count}");
                foreach (var participant in ev.Participants.OrderBy(p => p))
                {
                    Console.WriteLine(participant);
                }
            }
        }
    }

    public class Event
    {
        public List<string> Participants { get; set; }
        public string Name { get; }
        public int Id { get; }

        public Event(int id, string name, List<string> participants)
        {
            Id = id;
            Name = name;
            Participants = participants;
        }
    }
}
