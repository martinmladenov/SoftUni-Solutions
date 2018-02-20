using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> byDoctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> byDepartments = new Dictionary<string, List<List<string>>>();
            
            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] split = command.Split();
                var department = split[0];
                var firstName = split[1];
                var surname = split[2];
                var patient = split[3];
                var fullName = firstName + surname;

                if (!byDoctors.ContainsKey(firstName + surname))
                {
                    byDoctors[fullName] = new List<string>();
                }
                if (!byDepartments.ContainsKey(department))
                {
                    byDepartments[department] = new List<List<string>>();
                    for (int room = 0; room < 20; room++)
                    {
                        byDepartments[department].Add(new List<string>());
                    }
                }

                bool hasRoom = byDepartments[department].SelectMany(x => x).Count() < 60;
                if (hasRoom)
                {
                    int room = 0;
                    byDoctors[fullName].Add(patient);
                    for (int roomIndex = 0; roomIndex < byDepartments[department].Count; roomIndex++)
                    {
                        if (byDepartments[department][roomIndex].Count < 3)
                        {
                            room = roomIndex;
                            break;
                        }
                    }
                    byDepartments[department][room].Add(patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", byDepartments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int room))
                {
                    Console.WriteLine(string.Join("\n", byDepartments[args[0]][room - 1].OrderBy(x => x)));
                }
                else
                {
                    Console.WriteLine(string.Join("\n", byDoctors[args[0] + args[1]].OrderBy(x => x)));
                }
                command = Console.ReadLine();
            }
        }
    }
}
