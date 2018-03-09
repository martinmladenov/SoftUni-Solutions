using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Enterprise : IEnterprise
{
    private Dictionary<Guid, Employee> byGuid;

    public Enterprise()
    {
        byGuid = new Dictionary<Guid, Employee>();
    }

    public int Count => byGuid.Values.Count;

    public void Add(Employee employee)
    {
        if (byGuid.ContainsKey(employee.Id))
            return;

        byGuid.Add(employee.Id, employee);
    }

    public IEnumerable<Employee> AllWithPositionAndMinSalary(Position position, double minSalary)
    {
        return byGuid.Values.Where(x => x.Position == position && x.Salary >= minSalary);
    }

    public bool Change(Guid guid, Employee newEmployee)
    {
        if (!byGuid.ContainsKey(guid))
        {
            return false;
        }

        Employee employee = byGuid[guid];

        employee.FirstName = newEmployee.FirstName;
        employee.LastName = newEmployee.LastName;
        employee.Position = newEmployee.Position;
        employee.Salary = newEmployee.Salary;
        employee.HireDate = newEmployee.HireDate;

        return true;
    }

    public bool Contains(Guid guid)
    {
        return byGuid.ContainsKey(guid);
    }

    public bool Contains(Employee employee)
    {
        return byGuid.ContainsKey(employee.Id);
    }

    public bool Fire(Guid guid)
    {
        if (!byGuid.ContainsKey(guid))
        {
            return false;
        }

        byGuid.Remove(guid);

        return true;
    }

    public Employee GetByGuid(Guid guid)
    {
        if (!byGuid.ContainsKey(guid))
        {
            throw new ArgumentException();
        }

        return byGuid[guid];
    }

    public IEnumerable<Employee> GetByPosition(Position position)
    {
        var employees = byGuid.Values.Where(x => x.Position.Equals(position));

        if (!employees.Any())
        {
            throw new ArgumentException();
        }

        return employees;
    }

    public IEnumerable<Employee> GetBySalary(double minSalary)
    {
        var employees = byGuid.Values.Where(x => x.Salary >= minSalary);

        if (!employees.Any())
        {
            throw new InvalidOperationException();
        }

        return employees;
    }

    public IEnumerable<Employee> GetBySalaryAndPosition(double salary, Position position)
    {
        var employees = byGuid.Values.Where(e => e.Salary.Equals(salary) && e.Position.Equals(position));

        if (!employees.Any())
        {
            throw new InvalidOperationException();
        }

        return employees;
    }

    public IEnumerator<Employee> GetEnumerator()
    {
        foreach (var employee in byGuid.Values)
        {
            yield return employee;
        }
    }

    public Position PositionByGuid(Guid guid)
    {
        if (!this.byGuid.ContainsKey(guid))
        {
            throw new InvalidOperationException();
        }

        return GetByGuid(guid).Position;
    }

    public bool RaiseSalary(int months, int percent)
    {
        DateTime maxHireDate = DateTime.Now.AddMonths(-months);

        bool found = false;

        foreach (var employee in byGuid.Values.Where(e => e.HireDate <= maxHireDate))
        {
            found = true;
            employee.Salary *= 1 + percent / 100d;
        }

        return found;
    }

    public IEnumerable<Employee> SearchByFirstName(string firstName)
    {
        return byGuid.Values.Where(x => x.FirstName == firstName);
    }

    public IEnumerable<Employee> SearchByNameAndPosition(string firstName, string lastName, Position position)
    {
        return byGuid.Values.Where(x => x.Position == position && x.FirstName == firstName && x.LastName == lastName);
    }

    public IEnumerable<Employee> SearchByPosition(IEnumerable<Position> positions)
    {
        return byGuid.Values.Where(x => positions.Contains(x.Position));
    }

    public IEnumerable<Employee> SearchBySalary(double minSalary, double maxSalary)
    {
        return byGuid.Values.Where(x => x.Salary >= minSalary && x.Salary <= maxSalary);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

