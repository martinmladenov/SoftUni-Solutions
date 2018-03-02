using System;
using System.Collections.Generic;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    public Commando(int id, string firstName, string lastName, double salary, Corps corps, List<Mission> missions) : base(id, firstName, lastName, salary, corps)
    {
        Missions = missions;
    }

    public List<Mission> Missions { get; }

    public override string ToString()
    {
        var sb = new StringBuilder($"{base.ToString()}" + Environment.NewLine);
        sb.AppendLine("Missions:");
        sb.AppendLine($"  {string.Join(Environment.NewLine + "  ", Missions)}");
        return sb.ToString().Trim();
    }
}
