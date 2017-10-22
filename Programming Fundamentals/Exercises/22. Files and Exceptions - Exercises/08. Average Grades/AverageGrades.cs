namespace _8.Average_Grades
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class AverageGrades
    {
        public static void Main()
        {
            var list = new List<Student>();
            var input = File.ReadAllLines("input.txt");
            int n = int.Parse(input[0]);
            for (int i = 1; i <= n; i++)
            {
                var split = input[i].Split();
                list.Add(new Student(
                    split[0],
                    split.Skip(1)
                        .Select(double.Parse)
                        .ToArray()));
            }
            var output = list
                .Where(s => s.Average >= 5)
                .OrderBy(s => s.Name)
                .ThenByDescending(s => s.Average)
                .Select(s => $"{s.Name} -> {s.Average:f2}")
                .ToList();
            File.WriteAllLines("output.txt", output);
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
