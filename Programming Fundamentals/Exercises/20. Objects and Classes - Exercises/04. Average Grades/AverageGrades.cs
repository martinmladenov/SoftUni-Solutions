namespace _04.Average_Grades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AverageGrades
    {
        public static void Main()
        {
            var list = new List<Student>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var split = Console.ReadLine().Split();
                list.Add(new Student(
                    split[0],
                    split.Skip(1)
                        .Select(double.Parse)
                        .ToArray()));
            }
            foreach (var student in list
                .Where(s => s.Average >= 5)
                .OrderBy(s => s.Name)
            .ThenByDescending(s => s.Average))
            {
                Console.WriteLine($"{student.Name} -> {student.Average:f2}");
            }
        }
    }

    public class Student
    {
        public string Name;
        public double[] Grades;
        public double Average => Grades.Average();

        public Student(string name, double[] grades)
        {
            Name = name;
            Grades = grades;
        }
    }
}
