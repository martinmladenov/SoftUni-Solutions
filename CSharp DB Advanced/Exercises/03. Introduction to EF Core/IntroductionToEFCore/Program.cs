namespace P02_DatabaseFirst
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Data.Models;

    public class Program
    {
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {
                //P03(context);
                //P04(context);
                //P05(context);
                //P06(context);
                //P07(context);
                //P08(context);
                //P09(context);
                //P10(context);
                //P11(context);
                //P12(context);
                //P13(context);
                P14(context);
            }
        }

        private static void P03(SoftUniContext context)
        {
            foreach (var employee in context.Employees.OrderBy(e => e.EmployeeId))
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName}" +
                                  $" {employee.MiddleName} {employee.JobTitle}" +
                                  $" {employee.Salary:f2}");
            }
        }

        private static void P04(SoftUniContext context)
        {
            foreach (var employee in context.Employees.Where(e => e.Salary > 50000).OrderBy(e => e.FirstName))
            {
                Console.WriteLine(employee.FirstName);
            }
        }

        private static void P05(SoftUniContext context)
        {
            foreach (var employee in context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                }))
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:f2}");
            }
        }

        private static void P06(SoftUniContext context)
        {
            var address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Employees.First(e => e.LastName == "Nakov").Address = address;

            context.SaveChanges();

            foreach (var addressText in context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText))
            {
                Console.WriteLine(addressText);
            }
        }

        private static void P07(SoftUniContext context)
        {
            foreach (var employee in context.Employees
                .Where(e => e.EmployeesProjects.Any(ep =>
                    ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Take(30)
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName
                }))
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in context.Projects
                    .Where(e => e.EmployeesProjects.Any(ep => ep.EmployeeId == employee.EmployeeId)))
                {
                    string format = "M/d/yyyy h:mm:ss tt";
                    Console.WriteLine($"--{project.Name} - {project.StartDate.ToString(format, CultureInfo.InvariantCulture)} - {(project.EndDate == null ? "not finished" : project.EndDate.Value.ToString(format, CultureInfo.InvariantCulture))}");
                }
            }
        }

        private static void P08(SoftUniContext context)
        {
            foreach (var address in context.Addresses
                .Select(a => new
                {
                    EmployeeCount = a.Employees.Count,
                    TownName = a.Town.Name,
                    a.AddressText
                })
                .OrderByDescending(a => a.EmployeeCount)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10))
            {
                Console.WriteLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
            }
        }

        private static void P09(SoftUniContext context)
        {
            Employee emp = context.Employees.Find(147);

            Console.WriteLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");

            foreach (var project in context.Projects
                .Where(p => p.EmployeesProjects.Any(ep => ep.EmployeeId == emp.EmployeeId))
                .OrderBy(p => p.Name))
            {
                Console.WriteLine(project.Name);
            }
        }

        private static void P10(SoftUniContext context)
        {
            foreach (var d in context.Departments
                .Select(d => new
                {
                    d.Employees,
                    d.Name,
                    d.Manager.FirstName,
                    d.Manager.LastName
                })
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name))
            {
                Console.WriteLine($"{d.Name} - {d.FirstName} {d.LastName}");

                foreach (var e in d.Employees
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName))
                {
                    Console.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }

                Console.WriteLine(new string('-', 10));
            }
        }

        private static void P11(SoftUniContext context)
        {
            foreach (var p in context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name))
            {
                Console.WriteLine(p.Name);
                Console.WriteLine(p.Description);
                Console.WriteLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }
        }

        private static void P12(SoftUniContext context)
        {
            string[] departmentsList =
            {
                "Engineering",
                "Tool Design",
                "Marketing",
                "Information Services"
            };

            foreach (var e in context.Employees
                .Where(e => departmentsList.Contains(e.Department.Name)))
            {
                e.Salary *= 1.12m;
            }

            context.SaveChanges();

            foreach (var e in context.Employees
                .Where(e => departmentsList.Contains(e.Department.Name))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName))
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }
        }

        private static void P13(SoftUniContext context)
        {
            foreach(var e in context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName))
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }
        }

        private static void P14(SoftUniContext context)
        {
            Project project = context.Projects.Find(2);

            foreach (var ep in context.EmployeesProjects.Where(ep => ep.Project == project))
            {
                context.EmployeesProjects.Remove(ep);
            }

            context.Projects.Remove(project);

            context.SaveChanges();

            foreach (var p in context.Projects.Take(10))
            {
                Console.WriteLine(p.Name);
            }
        }
    }
}
