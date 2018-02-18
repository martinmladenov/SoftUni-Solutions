// ReSharper disable CheckNamespace
public class Company
{
    public string Name { get; }
    public string Department { get; }
    public double Salary { get; }

    public Company(string name, string department, double salary)
    {
        Name = name;
        Department = department;
        Salary = salary;
    }
}
