using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    public PersonCollection()
    {
        byEmail = new Dictionary<string, Person>();
        byDomain = new Dictionary<string, SortedDictionary<string, Person>>();
        byNameAndTown = new Dictionary<string, SortedDictionary<string, Person>>();
        byAge = new OrderedDictionary<int, SortedDictionary<string, Person>>();
        byTownAndAge = new Dictionary<string, OrderedDictionary<int, SortedDictionary<string, Person>>>();
    }

    private Dictionary<string, Person> byEmail;
    private Dictionary<string, SortedDictionary<string, Person>> byDomain;
    private Dictionary<string, SortedDictionary<string, Person>> byNameAndTown;
    private OrderedDictionary<int, SortedDictionary<string, Person>> byAge;
    private Dictionary<string, OrderedDictionary<int, SortedDictionary<string, Person>>> byTownAndAge;

    public bool AddPerson(string email, string name, int age, string town)
    {
        if (byEmail.ContainsKey(email))
        {
            return false;
        }

        Person person = new Person(email, name, age, town);

        byEmail.Add(email, person);

        string domain = email.Split('@')[1];
        if (!byDomain.ContainsKey(domain))
            byDomain.Add(domain, new SortedDictionary<string, Person>());
        byDomain[domain].Add(email, person);

        string nameTown = name + " " + town;
        if (!byNameAndTown.ContainsKey(nameTown))
            byNameAndTown.Add(nameTown, new SortedDictionary<string, Person>());
        byNameAndTown[nameTown].Add(email, person);

        if (!byAge.ContainsKey(age))
            byAge.Add(age, new SortedDictionary<string, Person>());
        byAge[age].Add(email, person);

        if (!byTownAndAge.ContainsKey(town))
            byTownAndAge.Add(town, new OrderedDictionary<int, SortedDictionary<string, Person>>());
        if (!byTownAndAge[town].ContainsKey(age))
            byTownAndAge[town].Add(age, new SortedDictionary<string, Person>());
        byTownAndAge[town][age].Add(email, person);

        return true;
    }

    public int Count => byEmail.Count;


    public Person FindPerson(string email)
    {
        if (!byEmail.ContainsKey(email))
        {
            return null;
        }

        return byEmail[email];
    }

    public bool DeletePerson(string email)
    {
        if (!byEmail.ContainsKey(email))
        {
            return false;
        }

        Person person = byEmail[email];

        byEmail.Remove(email);

        byDomain[email.Split('@')[1]].Remove(email);

        byNameAndTown[person.Name + " " + person.Town].Remove(email);

        byAge[person.Age].Remove(email);

        byTownAndAge[person.Town][person.Age].Remove(email);

        return true;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        if (!byDomain.ContainsKey(emailDomain))
        {
            return new Person[0];
        }

        return byDomain[emailDomain].Values;
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        string nameTown = name + " " + town;

        if (!byNameAndTown.ContainsKey(nameTown))
        {
            return new Person[0];
        }

        return byNameAndTown[nameTown].Values;
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        return byAge.Range(startAge, true, endAge, true).Values.SelectMany(dict => dict.Values);
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        if (!byTownAndAge.ContainsKey(town))
        {
            return new Person[0];
        }

        return byTownAndAge[town].Range(startAge, true, endAge, true).Values.SelectMany(dict => dict.Values);
    }
}
