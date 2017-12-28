namespace _04.Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Hospital
    {
        static void Main()
        {
            var patientsByDepartment = new Dictionary<string, List<string>>();
            var patientsByDoctor = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine().Trim()) != "Output")
            {
                var spl = input.Split();
                string department = spl[0];
                string doctor = $"{spl[1]} {spl[2]}";
                string patient = spl[3];

                if (!patientsByDepartment.ContainsKey(department))
                    patientsByDepartment.Add(department, new List<string>());
                patientsByDepartment[department].Add(patient);

                if (!patientsByDoctor.ContainsKey(doctor))
                    patientsByDoctor.Add(doctor, new List<string>());
                patientsByDoctor[doctor].Add(patient);
            }

            while ((input = Console.ReadLine().Trim()) != "End")
            {
                if (!input.Contains(" ") && patientsByDepartment.ContainsKey(input))
                {
                    Console.WriteLine(string.Join(Environment.NewLine,
                        patientsByDepartment[input]));
                    continue;
                }

                if (patientsByDoctor.ContainsKey(input))
                {
                    Console.WriteLine(string.Join(Environment.NewLine,
                        patientsByDoctor[input].OrderBy(p => p)));
                    continue;
                }

                var split = input.Split();
                string department = split[0];
                int room = int.Parse(split[1]);
                Console.WriteLine(string.Join(Environment.NewLine,
                    patientsByDepartment[department]
                    .Skip((room - 1) * 3)
                    .Take(3)
                    .OrderBy(p => p)));
            }
        }
    }
}
