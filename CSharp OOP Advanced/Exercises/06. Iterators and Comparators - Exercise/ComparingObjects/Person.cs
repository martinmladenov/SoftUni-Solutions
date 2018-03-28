namespace ComparingObjects
{
    using System;

    public class Person:IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public string Name { get; }
        public int Age { get; }
        public string Town { get; }


        public int CompareTo(Person other)
        {
            int cmp = Name.CompareTo(other.Name);

            if (cmp == 0)
            {
                cmp = Age.CompareTo(other.Age);

                if (cmp == 0)
                {
                    cmp = Town.CompareTo(other.Town);
                }
            }

            return cmp;
        }
    }
}
