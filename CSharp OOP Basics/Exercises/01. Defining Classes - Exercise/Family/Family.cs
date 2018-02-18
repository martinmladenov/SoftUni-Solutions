// ReSharper disable CheckNamespace
// ReSharper disable UnusedMember.Global

using System.Collections.Generic;
using System.Linq;

public class Family
{
    private List<Person> people;

    public Family()
    {
        people = new List<Person>();
    }

    public void AddMember(Person member)
    {
        people.Add(member);
    }

    public Person GetOldestMember()
    {
        return people.OrderByDescending(p => p.Age).First();
    }
}
