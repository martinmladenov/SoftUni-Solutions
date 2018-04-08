namespace P04_WorkForce
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<Employee> employees = new List<Employee>();
            List<Job> jobs = new List<Job>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var split = input.Split();

                switch (split[0])
                {
                    case "Job":
                        {
                            string name = split[1];
                            int hours = int.Parse(split[2]);
                            Employee employee = employees.FirstOrDefault(e => e.Name == split[3]);

                            Job job = new Job(name, hours, employee);
                            job.JobFinished += (obj, args) => jobs.Remove((Job)obj);

                            jobs.Add(job);
                            break;
                        }
                    case "StandardEmployee":
                        {
                            string name = split[1];
                            employees.Add(new StandardEmployee(name));
                            break;
                        }
                    case "PartTimeEmployee":
                        {
                            string name = split[1];
                            employees.Add(new PartTimeEmployee(name));
                            break;
                        }
                    case "Pass":
                        {
                            foreach (var job in jobs.ToArray())
                            {
                                job.Update();
                            }

                            break;
                        }
                    case "Status":
                        {
                            foreach (var job in jobs)
                            {
                                Console.WriteLine($"Job: {job.Name} Hours Remaining: {job.HoursRemaining}");
                            }

                            break;
                        }
                }
            }
        }
    }
}
