using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Organization : IOrganization
{
    private HashSet<Person> all;
    private List<Person> byInsertOrder;
    private Dictionary<string, HashSet<Person>> byName;
    private OrderedDictionary<int, HashSet<Person>> byNameSize;

    public Organization()
    {
        all = new HashSet<Person>();
        byInsertOrder = new List<Person>();
        byName = new Dictionary<string, HashSet<Person>>();
        byNameSize = new OrderedDictionary<int, HashSet<Person>>();
    }

    public int Count => byInsertOrder.Count;

    public bool Contains(Person person)
    {
        return all.Contains(person);
    }

    public bool ContainsByName(string name)
    {
        return byName.ContainsKey(name);
    }

    public void Add(Person person)
    {
        all.Add(person);

        byInsertOrder.Add(person);

        if (!byName.ContainsKey(person.Name))
        {
            byName.Add(person.Name, new HashSet<Person>());
        }
        byName[person.Name].Add(person);

        if (!byNameSize.ContainsKey(person.Name.Length))
        {
            byNameSize.Add(person.Name.Length, new HashSet<Person>());
        }
        byNameSize[person.Name.Length].Add(person);
    }

    public Person GetAtIndex(int index)
    {
        if (index >= Count)
        {
            throw new IndexOutOfRangeException();
        }

        return byInsertOrder[index];
    }

    public IEnumerable<Person> GetByName(string name)
    {
        if (!byName.ContainsKey(name))
        {
            return Enumerable.Empty<Person>();
        }

        return byName[name];
    }

    public IEnumerable<Person> FirstByInsertOrder(int count = 1)
    {
        return byInsertOrder.Take(count);
    }

    public IEnumerable<Person> SearchWithNameSize(int minLength, int maxLength)
    {
        foreach (var keyValuePair in byNameSize.Range(minLength,true,maxLength,true))
        {
            foreach (var person in keyValuePair.Value)
            {
                yield return person;
            }
        }
    }

    public IEnumerable<Person> GetWithNameSize(int length)
    {
        if (!byNameSize.TryGetValue(length, out var hashSet))
        {
            throw new ArgumentException();
        }

        return hashSet;
    }

    public IEnumerable<Person> PeopleByInsertOrder()
    {
        return byInsertOrder;
    }

    public IEnumerator<Person> GetEnumerator()
    {
        return byInsertOrder.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}