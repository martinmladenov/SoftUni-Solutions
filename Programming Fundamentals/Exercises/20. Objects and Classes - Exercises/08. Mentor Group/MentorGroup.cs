namespace _08.Mentor_Group
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class MentorGroup
    {
        public static void Main()
        {
            var students = new List<Student>();
            string input;
            while ((input = Console.ReadLine()) != "end of dates")
            {
                var split = input.Split(' ', ',');
                var student = students.FirstOrDefault(s => s.Name == split[0]);
                if (student == null)
                {
                    student = new Student(split[0]);
                    students.Add(student);
                }

                student.Dates.AddRange(split
                    .Skip(1)
                    .Select(s => DateTime.ParseExact(s, "dd/MM/yyyy", CultureInfo.InvariantCulture)));
            }
            while ((input = Console.ReadLine()) != "end of comments")
            {
                var split = input.Split('-');
                var student = students.FirstOrDefault(s => s.Name == split[0]);
                student?.Comments.Add(split[1]);
            }
            foreach (var student in students.OrderBy(s => s.Name))
            {
                Console.WriteLine(student.Name);
                Console.WriteLine("Comments:");
                foreach (var comment in student.Comments)
                {
                    Console.WriteLine($"- {comment}");
                }
                Console.WriteLine("Dates attended:");
                foreach (var date in student.Dates.OrderBy(d => d))
                {
                    Console.WriteLine($"-- {date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}");
                }
            }
        }
    }

    public class Student
    {
        public string Name;
        public List<DateTime> Dates;
        public List<string> Comments;

        public Student(string name)
        {
            Name = name;
            Dates = new List<DateTime>();
            Comments = new List<string>();
        }
    }
}
