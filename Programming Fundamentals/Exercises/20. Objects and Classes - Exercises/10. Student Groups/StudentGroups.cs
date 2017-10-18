namespace _10.Student_Groups
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class StudentGroups
    {
        public static void Main()
        {
            var towns = new List<Town>();
            Town currentTown = null;
            var students = new List<Student>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    FinishTown(currentTown, students, towns);
                    break;
                }
                if (input.Contains("=>"))
                {
                    int separatorIndex = input.IndexOf('=');
                    string name = input.Substring(0, separatorIndex - 1);
                    int capacity = int.Parse(input.Substring(separatorIndex + 3).Split()[0]);
                    if (currentTown != null)
                    {
                        FinishTown(currentTown, students, towns);
                    }
                    students.Clear();
                    currentTown = new Town(name, capacity);
                    continue;
                }
                var split = input
                    .Split('|')
                    .Select(s => s.Trim())
                    .ToArray();
                students.Add(new Student(split[0], split[1], split[2]));
            }
            int groupsCount = towns.Sum(t => t.Groups.Count);
            Console.WriteLine($"Created {groupsCount} groups in {towns.Count} towns:");
            foreach (var town in towns.OrderBy(t => t.Name))
            {
                foreach (var group in town.Groups)
                {
                    Console.WriteLine(town.Name + " => " +
                        string.Join(", ", group.Select(s => s.Email)));
                }
            }
        }

        private static void FinishTown(Town currentTown, List<Student> students, List<Town> towns)
        {
            int oldCapacity = currentTown.LabCapacity;
            for (int i = 0; i < (double)students.Count / currentTown.LabCapacity; i++)
            {
                students = students
                    .OrderBy(s => s.RegistrationDate)
                    .ThenBy(s => s.Name)
                    .ThenBy(s => s.Email)
                    .ToList();
                currentTown.Groups.Add(students.Skip(i * oldCapacity)
                    .Take(oldCapacity).ToArray());
            }
            towns.Add(currentTown);
        }
    }

    public class Town
    {
        public string Name;
        public List<Student[]> Groups;
        public int LabCapacity;

        public Town(string name, int capacity)
        {
            Name = name;
            LabCapacity = capacity;
            Groups = new List<Student[]>();
        }
    }

    public class Student
    {
        public string Name;
        public string Email;
        public DateTime RegistrationDate;

        public Student(string name, string email, string registrationDate)
        {
            Name = name;
            Email = email;
            RegistrationDate = DateTime.ParseExact(registrationDate, "d-MMM-yyyy", CultureInfo.InvariantCulture);
        }
    }
}
