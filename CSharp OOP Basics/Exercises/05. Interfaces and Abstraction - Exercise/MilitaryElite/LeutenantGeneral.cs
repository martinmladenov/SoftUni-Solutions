using System;
using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public LeutenantGeneral(int id, string firstName, string lastName, double salary, List<Private> privates) : base(id, firstName, lastName, salary)
    {
        Privates = privates;
    }

    public List<Private> Privates { get; }

    public override string ToString()
    {
        var sb = new StringBuilder($"{base.ToString()}" + Environment.NewLine);
        sb.AppendLine("Privates:");
        sb.AppendLine($"  {string.Join(Environment.NewLine + "  ", Privates)}");
        return sb.ToString().Trim();
    }
}
