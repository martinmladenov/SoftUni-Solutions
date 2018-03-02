using System;
using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public Engineer(int id, string firstName, string lastName, double salary, Corps corps, List<Repair> repairs) : base(id, firstName, lastName, salary, corps)
    {
        Repairs = repairs;
    }

    public List<Repair> Repairs { get; }

    public override string ToString()
    {
        var sb = new StringBuilder($"{base.ToString()}" + Environment.NewLine);
        sb.AppendLine("Repairs:");
        sb.AppendLine($"  {string.Join(Environment.NewLine + "  ", Repairs)}");
        return sb.ToString().Trim();
    }
}
