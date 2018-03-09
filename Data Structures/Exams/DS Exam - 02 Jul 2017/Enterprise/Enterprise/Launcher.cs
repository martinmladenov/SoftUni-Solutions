using System;
using System.Collections.Generic;
using System.Linq;

class Launcher
{
    static void Main(string[] args)
    {
        IEnterprise enterprise = new Enterprise();
        Employee employee = new Employee("pesho", "123", 62342, Position.Hr, DateTime.Now);
        Employee employee1 = new Employee("a", "321", 51255, Position.Owner, DateTime.Now);
        Employee employee2 = new Employee("c", "111", 11266, Position.Hr, DateTime.Now);
        Employee employee3 = new Employee("d", "11111", 1156123, Position.Developer, DateTime.Now);
        Employee employee4 = new Employee("e", "11111", 126126, Position.Developer, DateTime.Now);

        Employee[] employees = new Employee[]{
            employee,
            employee1,
            employee2,
            employee3,
            employee4
        };

        Employee[] expected = new Employee[] {
            employee,
            employee2
        };

        var ex2 = expected.Select(s => s.FirstName).ToArray();

        foreach (Employee e in employees)
        {
            enterprise.Add(e);
        }

        var all = enterprise.AllWithPositionAndMinSalary(Position.Hr, 1).Select(e => e.FirstName).ToArray();
    }
}
