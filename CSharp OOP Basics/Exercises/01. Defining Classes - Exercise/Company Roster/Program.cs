using System;
using System.Linq;

// ReSharper disable CheckNamespace

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Employee[] employees = new Employee[n];

        for (int i = 0; i < n; i++)
        {
            string[] split = Console.ReadLine().Split();
            string name = split[0];
            double salary = double.Parse(split[1]);
            string position = split[2];
            string department = split[3];
            string email;
            int age;
            if (split.Length < 5)
            {
                email = "n/a";
                age = -1;
            }
            else if (split.Length < 6)
            {
                if (int.TryParse(split[4], out age))
                {
                    email = "n/a";
                }
                else
                {
                    age = -1;
                    email = split[4];
                }
            }
            else
            {
                email = split[4];
                age = int.Parse(split[5]);
            }
            employees[i] = new Employee(name, salary, position, department, email, age);
        }

        var highestPaidDepartment = employees.GroupBy(e => e.Department)
            .OrderByDescending(
                g => g.Average(e => e.Salary))
            .First();

        Console.WriteLine($"Highest Average Salary: {highestPaidDepartment.Key}");

        foreach (var employee in highestPaidDepartment.OrderByDescending(e => e.Salary))
        {
            Console.WriteLine(employee);
        }

    }
}
